using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private MeshRenderer _magazineMeshRenderer;

    [SerializeField] private bool _failed = false;
    
    private void Start()
    {
        if(_failed) _magazineMeshRenderer.material = GameController.Instance.CurrentSceneAndGameoverMagazine._gameoverMagazineMaterial;
        
        GameController.Instance.PlayerController.PlayerInputs.Enable();
        
        GameController.Instance.PlayerController.PlayerInputs.FPS_UI.AnyButton.performed += (callbackContext) =>
        {
            GameController.Instance.PlayerController.PlayerInputs.Disable();
            GameController.Instance.StartCoroutine(GameController.Instance.GoToMainMenu());
        };
    }
}
