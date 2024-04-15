using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private MeshRenderer _magazineMeshRenderer;

    [SerializeField] private bool _failed = false;

    private Action<InputAction.CallbackContext> inputHandler;
    
    private void Start()
    {
        if(_failed) _magazineMeshRenderer.material = GameController.Instance.CurrentSceneAndGameoverMagazine._gameoverMagazineMaterial;
        
        GameController.Instance.PlayerController.PlayerInputs.Enable();
        
        inputHandler = (InputAction.CallbackContext callbackContext) =>
        {
            GameController.Instance.PlayerController.PlayerInputs.FPS_UI.AnyButton.Reset();
            GameController.Instance.PlayerController.PlayerInputs.Disable();
            GameController.Instance.StartCoroutine(GameController.Instance.GoToMainMenu());
        };

        GameController.Instance.PlayerController.PlayerInputs.FPS_UI.AnyButton.performed += inputHandler;
    }

    private void OnDisable()
    {
        GameController.Instance.PlayerController.PlayerInputs.FPS_UI.AnyButton.performed -= inputHandler;
    }
}
