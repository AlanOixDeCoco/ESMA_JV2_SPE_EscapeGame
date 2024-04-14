using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private RectTransform _loadingScreenPanel;
    
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        GameController.Instance.SetGameUI(this);
    }

    public void ShowLoadingScreen(bool show)
    {
        Debug.Log(show);
        _loadingScreenPanel.gameObject.SetActive(show);
    }
}
