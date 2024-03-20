using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject _gameControllerPrefab;

    [SerializeField] private UnityEvent _beforeStart, _onStart;

    private void Start()
    {
        // Execute code before being ready for the game controller to take control
        _beforeStart.Invoke();
        
        // Inform the Game Controller that the level is ready
        GameController.Instance.OnLevelReady(this);
    }

    public void StartLevel()
    {
        _onStart.Invoke();
    }

    public void Success()
    {
        GameController.Instance.OnLevelSuccess();
    }

    public void Fail()
    {
        GameController.Instance.OnLevelFail();
    }
}
