using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private UnityEvent _onLoad, _onStart;

    private bool _hasEnded = false;

    private void Start()
    {
        // Execute code before being ready for the game controller to take control
        _onLoad.Invoke();
        
        // Inform the Game Controller that the level is ready
        GameController.Instance.SetActiveSceneController(this);
    }

    public void StartScene()
    {
        _onStart.Invoke();
    }

    public void DebugRestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    public void OnLevelSuccess()
    {
        if (!_hasEnded)
        {
            _hasEnded = true;
            GameController.Instance.StartCoroutine(GameController.Instance.OnLevelSuccess());
        }
    }

    public void OnLevelFail()
    {
        if (!_hasEnded)
        {
            _hasEnded = true;
            GameController.Instance.StartCoroutine(GameController.Instance.OnLevelFail());
        }
    }
}