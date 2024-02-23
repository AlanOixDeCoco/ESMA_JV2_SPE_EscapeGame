using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerManager))]
[RequireComponent(typeof(PlayerHand))]
public class PlayerLook : PlayerComponent
{
    [Header("References")]
    [SerializeField] private Transform _playerHeadTransform;
    
    [Header("Look settings")]
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _maxInteractionDistance = 1.5f;
    
    // Look state machine
    private LookState _activeLookState;

    private bool _aimingAtObject = false;
    private Transform _aimObject;
    
    private Transform _mainCameraTransform;
    private InputManager _inputManager;
    private PlayerManager _playerManager;

    public bool AimingAtObject => _aimingAtObject;

    public Transform AimObject => _aimObject;

    private void Start()
    {
        _mainCameraTransform = Camera.main.transform;
        _inputManager = InputManager.Instance;
        _playerManager = GetComponent<PlayerManager>();
        
        _inputManager.PlayerInputs.FPS_Gameplay.Interact.started += OnInteractAction;
        
        // Setup look state machine
        _activeLookState = new DefaultLookState(_playerManager, this);
        _activeLookState.OnEnterState();
    }

    private void Update()
    {
        _activeLookState.OnTick();
        
        _playerHeadTransform.forward = _mainCameraTransform.forward;

        _aimingAtObject = Physics.Raycast(
            _playerHeadTransform.position, 
            _mainCameraTransform.forward, 
            out var hit,
            _maxInteractionDistance, 
            _layerMask
            );

        if (_aimingAtObject) _aimObject = hit.transform;
    }

    public void SwitchLookState(LookState lookstate)
    {
        _activeLookState = lookstate;
        _activeLookState.OnEnterState();
    }

    private void OnInteractAction(InputAction.CallbackContext context)
    {
        _activeLookState.OnInteract();
    }
}