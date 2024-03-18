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
    
    
    private void Awake()
    {
        #region Singleton constructor
        // Destroy current instance if there is already a Game Controller instance
        if (_instance == null) _instance = this;
        else Destroy(gameObject);
        #endregion
        
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        SceneManager.LoadScene("scene_Tutorial");
    }
}
