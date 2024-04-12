using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private int _transitionSceneIndex = 2;
    
    public void StartGame()
    {
        SceneManager.LoadScene(_transitionSceneIndex);
    }
}
