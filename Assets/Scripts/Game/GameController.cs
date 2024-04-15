using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

[Serializable]
public class SceneAndGameoverMagazine
{
    public string _sceneName;
    public Material _gameoverMagazineMaterial;
}

public class GameController : MonoBehaviour
{
    #region Singleton variables
    private static GameController _instance;
    public static GameController Instance => _instance;
    #endregion

    #region Controllers references

    [Header("Controllers references")]
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private TimeController _timeController;
    [SerializeField] private AudioController _audioController;
    public PlayerController PlayerController => _playerController;
    public TimeController TimeController => _timeController;
    public AudioController AudioController => _audioController;

    #endregion

    #region Scenes

    [Header("Scenes")] 
    [SerializeField] private string _mainMenuScene;
    [SerializeField] private string _successGameOverScene;
    [SerializeField] private string _failGameOverScene;
    [SerializeField] private SceneAndGameoverMagazine _firstLevelScene;
    [SerializeField] private SceneAndGameoverMagazine[] _beginnerLevelsScenes;
    [SerializeField] private SceneAndGameoverMagazine[] _advancedLevelsScenes;

    private SceneController _activeSceneController;
    public SceneController ActiveSceneController => _activeSceneController;

    private List<SceneAndGameoverMagazine> _levelsQueue;

    private SceneAndGameoverMagazine _currentSceneAndGameoverMagazine;
    public SceneAndGameoverMagazine CurrentSceneAndGameoverMagazine => _currentSceneAndGameoverMagazine;
    #endregion

    #region Rules

    [Header("Rules")]
    [Tooltip("Game duration until gameover, in minutes")] [SerializeField] private float _gameDuration;
    public float GameDuration => _gameDuration;

    #endregion

    #region UI

    private GameUI _gameUI;
    public GameUI GameUI => _gameUI;

    public void SetGameUI(GameUI gameUI)
    {
        _gameUI = gameUI;
    }

    #endregion
    
    private void Awake()
    {
        #region Singleton constructor
        // Destroy current instance if there is already a Game Controller instance
        if (_instance == null) _instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        #endregion
        
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
    }

    public void SetActiveSceneController(SceneController sceneController)
    {
        _activeSceneController = sceneController;
    }

    public IEnumerator GoToMainMenu()
    {
        yield return StartCoroutine(FadeIn());
        
        var loadSceneAsync = SceneManager.LoadSceneAsync(_mainMenuScene);
        
        yield return new WaitUntil(() => loadSceneAsync.isDone);
        
        AudioController.PauseAmbiant();

        yield return StartCoroutine(FadeOut());
    }
    
    public IEnumerator StartGame()
    {
        _timeController.ResetTime();
        _levelsQueue = CreateNewLevelsQueue();
        yield return StartCoroutine(OnLevelSuccess());
    }

    public IEnumerator OnLevelSuccess()
    {
        _timeController.Pause();

        if (_levelsQueue.Count > 0) yield return StartCoroutine(StartNextLevel());
        else yield return StartCoroutine(Gameover(true));
    }

    public IEnumerator OnLevelFail()
    {
        _timeController.Pause();
        _levelsQueue = CreateNewLevelsQueue();

        yield return StartCoroutine(StartNextLevel());
    }

    private List<SceneAndGameoverMagazine> CreateNewLevelsQueue()
    {
        var newLevelsQueue = new List<SceneAndGameoverMagazine>();
        
        newLevelsQueue.Add(_firstLevelScene);
        
        var beginnerLevels = _beginnerLevelsScenes.ToList();
        var advancedLevels = _advancedLevelsScenes.ToList();

        for (int i = 0; i < _beginnerLevelsScenes.Length; i++)
        {
            int levelIndex = Random.Range(0, beginnerLevels.Count);
            
            newLevelsQueue.Add(beginnerLevels[levelIndex]);
            
            beginnerLevels.RemoveAt(levelIndex);
        }
        
        for (int i = 0; i < _advancedLevelsScenes.Length; i++)
        {
            int levelIndex = Random.Range(0, advancedLevels.Count);
            
            newLevelsQueue.Add(advancedLevels[levelIndex]);
            
            advancedLevels.RemoveAt(levelIndex);
        }

        return newLevelsQueue;
    }

    private IEnumerator StartNextLevel()
    {
        yield return StartCoroutine(FadeIn());

        _currentSceneAndGameoverMagazine = _levelsQueue.First();
        
        var loadSceneAsync = SceneManager.LoadSceneAsync(_levelsQueue.First()._sceneName);
        _levelsQueue.RemoveAt(0);
        
        yield return new WaitUntil(() => loadSceneAsync.isDone);
        
        yield return StartCoroutine(FadeOut());
        
        _timeController.Resume();
    }

    private IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(2f);
        
        _playerController.PlayerInputs.Disable();

        AudioController.PauseAmbiant();
        yield return StartCoroutine(GameUI.FadeInOut.FadeIn(2f));
    }
    
    private IEnumerator FadeOut()
    {
        AudioController.PlayAmbiant();
        yield return StartCoroutine(GameUI.FadeInOut.FadeOut(1f));
        
        _playerController.PlayerInputs.Enable();
    }

    public IEnumerator Gameover(bool success)
    {
        yield return StartCoroutine(FadeIn());

        var sceneToLoad = success ? _successGameOverScene : _failGameOverScene;
        
        var loadSceneAsync = SceneManager.LoadSceneAsync(sceneToLoad);
        
        yield return new WaitUntil(() => loadSceneAsync.isDone);

        yield return StartCoroutine(FadeOut());
        
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void ExitGame()
    {
        StartCoroutine(ExitGameCoroutine());
    }

    private IEnumerator ExitGameCoroutine()
    {
        yield return StartCoroutine(GameUI.FadeInOut.FadeIn(1f));
        
        Application.Quit();
    }
}
