using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private int _transitionSceneIndex = 2;

    private void Start()
    {
        GameController.Instance.GameUI.ShowLoadingScreen(false);
    }

    public void StartGame()
    {
        GameController.Instance.StartCoroutine(StartGameCoroutine());
    }

    public void ExitGame()
    {
        GameController.Instance.ExitGame();
    }

    private IEnumerator StartGameCoroutine()
    {
        yield return GameController.Instance.StartCoroutine(GameController.Instance.GameUI.FadeInOut.FadeIn(.5f));
        
        var loadSceneAsync = SceneManager.LoadSceneAsync(_transitionSceneIndex);
        yield return new WaitUntil(() => loadSceneAsync.isDone);
        
        yield return GameController.Instance.StartCoroutine(GameController.Instance.GameUI.FadeInOut.FadeOut(.5f));
    }
}
