using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroductionController : MonoBehaviour
{
    public void StartGame()
    {
        GameController.Instance.StartCoroutine(GameController.Instance.StartGame());
    }
}
