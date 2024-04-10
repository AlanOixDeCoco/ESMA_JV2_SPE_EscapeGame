using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public PlayerController PlayerController => _playerController;
    #endregion

    #region Scenes

    [Header("Scenes")] 
    [SerializeField] private string _mainMenuScene;
    [SerializeField] private string _introductionScene;
    [SerializeField] private string _firstLevelScene;
    [SerializeField] private string _transitionScene;
    [SerializeField] private string[] _beginnerLevelsScenes;
    [SerializeField] private string[] _advancedLevelsScenes;

    private SceneController _activeSceneController;

    #endregion

    #region Rules

    [Header("Rules")]
    [Tooltip("Game duration until gameover, in minutes")] [SerializeField] private float _gameDuration;
    
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

    public void OnLevelReady(SceneController sceneController)
    {
        _activeSceneController = sceneController;
        _timeController.Resume();
    }

    public void OnLevelSuccess()
    {
        _timeController.Pause();
    }

    public void OnLevelFail()
    {
        _timeController.Pause();
    }
}
