using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerHand))]
public class PlayerLook : PlayerComponent
{
    [Header("Look settings")]
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _maxInteractionDistance = 1.5f;
    
    // Look state machine
    private LookState _activeLookState;

    private bool _aimingAtObject = false;
    private Transform _aimObject;
    private Transform _mainCameraTransform;

    private PlayerUI _playerUI;

    public bool AimingAtObject => _aimingAtObject;

    public Transform AimObject => _aimObject;

    public PlayerUI PlayerUI => _playerUI;

    private void Start()
    {
        _mainCameraTransform = Camera.main.transform;
        
        PlayerController.PlayerInputs.FPS_Gameplay.Interact.started += OnInteractAction;
        
        // Setup look state machine
        _activeLookState = new DefaultLookState(_playerManager, this);
        _activeLookState.OnEnterState();
    }

    private void Update()
    {
        _playerManager.PlayerHeadTransform.forward = _mainCameraTransform.forward;
        
        _activeLookState.OnTick();

        _aimingAtObject = Physics.Raycast(
            _playerManager.PlayerHeadTransform.position, 
            _mainCameraTransform.forward, 
            out var hit,
            _maxInteractionDistance, 
            _layerMask
            );

        if (_aimingAtObject) _aimObject = hit.transform;
    }

    public void SetUIReference(PlayerUI playerUI)
    {
        _playerUI = playerUI;
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