using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private UnityEvent _onLoad, _onStart;

    private void Start()
    {
        // Execute code before being ready for the game controller to take control
        _onLoad.Invoke();
        
        // Inform the Game Controller that the level is ready
        GameController.Instance.OnLevelReady(this);
    }

    private void StartScene()
    {
        _onStart.Invoke();
    }

    public void DebugRestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}
