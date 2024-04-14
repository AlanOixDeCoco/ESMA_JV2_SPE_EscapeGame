using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerManager))]
public class PlayerMovement : PlayerComponent
{
    [SerializeField] private float _playerSpeed = 2.0f;
    [SerializeField] private float _crouchOffset = -0.5f;
    [SerializeField] private float _crawlOffset = -1f;

    private CharacterController _characterController;
    private Vector3 _playerVelocity;
    private bool _grounded;
    private bool _crouching = false, _crawling = false;

    private float _baseCharacterHeight;
    
    private Transform _mainCameraTransform;

    private Vector3 _headPosition;

    private void OnEnable()
    {
        GameController.Instance.PlayerController.PlayerInputs.FPS_Gameplay.Crouch.performed += HandleCrouchInput;
        GameController.Instance.PlayerController.PlayerInputs.FPS_Gameplay.Crawl.performed += HandleCrawlStart;
    }
    
    private void OnDisable()
    {
        GameController.Instance.PlayerController.PlayerInputs.FPS_Gameplay.Crouch.performed -= HandleCrouchInput;
        GameController.Instance.PlayerController.PlayerInputs.FPS_Gameplay.Crawl.performed -= HandleCrawlStart;
    }

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _mainCameraTransform = Camera.main.transform;

        _baseCharacterHeight = _characterController.height;

        _headPosition = _playerManager.PlayerHeadTransform.localPosition;
    }

    void Update()
    {
        ProcessCrouch();
        ProcessMovement(GameController.Instance.PlayerController.PlayerInputs.FPS_Gameplay.Movement.ReadValue<Vector2>());

        _characterController.SimpleMove(_playerVelocity);
    }

    private void ProcessMovement(Vector2 input)
    {
        var forward = _mainCameraTransform.forward;
        forward.y = 0;
        forward.Normalize();
        forward *= input.y;

        var right = _mainCameraTransform.right;
        right.y = 0;
        right.Normalize();
        right *= input.x;

        var move = forward + right;
        move *= _playerSpeed;

        _playerVelocity.x = move.x;
        _playerVelocity.z = move.z;
    }

    private void ProcessCrouch()
    {
        var headOffset = _crouching ? _crouchOffset : 0;
        headOffset = _crawling ? _crawlOffset : headOffset;
        
        _characterController.height = Mathf.Lerp(_characterController.height,   _baseCharacterHeight + headOffset, Time.deltaTime * 10f);
        _characterController.center = Vector3.up * (_characterController.height / 2f);

        _playerManager.PlayerHeadTransform.localPosition = Vector3.up * _characterController.height;
    }

    private void HandleCrouchInput(InputAction.CallbackContext context)
    {
        if (_crawling)
        {
            _crawling = false;
            return;
        }
        _crouching = !_crouching;
    }

    private void HandleCrawlStart(InputAction.CallbackContext context)
    {
        _crawling = true;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        var body = hit.collider.attachedRigidbody;

        // no rigidbody
        if (body == null || body.isKinematic) { return; }

        // We dont want to push objects below us
        if (hit.moveDirection.y < -0.3) { return; }

        // Calculate push direction from move direction,
        // we only push objects to the sides never up and down
        var pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        // If you know how fast your character is trying to move,
        // then you can also multiply the push velocity by that.

        // Apply the push
        body.AddForceAtPosition(pushDir * 10, hit.point, ForceMode.Acceleration);
    }
}