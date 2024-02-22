using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerManager))]
public class PlayerLook : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Transform _playerHeadTransform;
    [SerializeField] private float _maxInteractionDistance = 1.5f;
    
    private Interactable _interactable;
    private Pickable _pickable;
    
    private Transform _mainCameraTransform;
    private InputManager _inputManager;
    private PlayerManager _playerManager;

    private void Start()
    {
        _mainCameraTransform = Camera.main.transform;
        _inputManager = InputManager.Instance;
        _playerManager = GetComponent<PlayerManager>();
        
        _inputManager.PlayerInputs.FPS_Gameplay.Interact.started += OnInteractAction;
    }

    private void Update()
    {
        _playerHeadTransform.forward = _mainCameraTransform.forward;
        
        if (Physics.Raycast(_playerHeadTransform.position, _mainCameraTransform.forward, out var hit, _maxInteractionDistance, _layerMask))
        {
            if (hit.transform.TryGetComponent<Interactable>(out _interactable))
            {
                _interactable.OnAim(_playerManager);
            }
            else if (hit.transform.TryGetComponent<Pickable>(out _pickable))
            {
                _pickable.OnAim(_playerManager);
            }
            else
            {
                UIManager.Instance.SetCrosshair(CrosshairModes.Dot);
            }
        }
        else
        {
            UIManager.Instance.SetCrosshair(CrosshairModes.Dot);
        }
    }

    private void OnInteractAction(InputAction.CallbackContext context)
    {
        _interactable?.OnInteract();
    }
}
