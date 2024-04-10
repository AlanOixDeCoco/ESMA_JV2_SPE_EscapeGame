using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    [SerializeField] private int _mainMenuSceneIndex = 1;
    
    private void Start()
    {
        SceneManager.LoadScene(_mainMenuSceneIndex);
    }
}
