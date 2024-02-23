using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerManager))]
public class DeprecatedPlayerLook : PlayerComponent
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Transform _playerHeadTransform;
    [SerializeField] private float _maxInteractionDistance = 1.5f;
    
    private Interactable _interactable;
    private Pickable _pickable;
    
    private Transform _mainCameraTransform;
    private InputManager _inputManager;
    private PlayerManager _playerManager;

    private bool _aimAtInteractable = false, _aimAtPickable = false;

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

        _aimAtInteractable = false;
        _aimAtPickable = false;

        if (Physics.Raycast(_playerHeadTransform.position, _mainCameraTransform.forward, out var hit,
                _maxInteractionDistance, _layerMask))
        {
            _aimAtInteractable = hit.transform.TryGetComponent<Interactable>(out _interactable);
            _aimAtPickable = hit.transform.TryGetComponent<Pickable>(out _pickable);
        }
        
        if(!(_aimAtPickable || _aimAtInteractable))
        {
            UIManager.Instance.SetCrosshair(CrosshairModes.Dot);
        }
    }

    private void OnInteractAction(InputAction.CallbackContext context)
    {
        if(_aimAtInteractable) _interactable.Interact(_playerManager);

        if (_aimAtPickable && _playerManager.TryGetReference<DeprecatedPlayerInspect>(out var playerInspect))
        {
            if (playerInspect.TryPickObject(_pickable.transform)) _pickable.Pick(_playerManager);
        }
    }
}
