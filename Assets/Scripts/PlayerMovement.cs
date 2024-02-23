using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerManager))]
public class PlayerMovement : PlayerComponent
{
    [SerializeField] private float _playerSpeed = 2.0f;
    [SerializeField] private Vector3 _crouchOffset = new (0, -0.5f, 0);
    [SerializeField] private Transform _headTransform;

    private CharacterController _characterController;
    private Vector3 _playerVelocity;
    private bool _grounded;

    private InputManager _inputManager;
    private Transform _mainCameraTransform;

    private Vector3 _headPosition;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _inputManager = InputManager.Instance;
        _mainCameraTransform = Camera.main.transform;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _headPosition = _headTransform.localPosition;
    }

    void Update()
    {
        ProcessMovement(_inputManager.PlayerInputs.FPS_Gameplay.Movement.ReadValue<Vector2>());

        ProcessCrouch(_inputManager.PlayerInputs.FPS_Gameplay.Crouch.ReadValue<float>());

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

    private void ProcessCrouch(float input)
    {
        _headTransform.localPosition = Vector3.Lerp(_headTransform.localPosition, _headPosition + ((int)input * _crouchOffset), Time.deltaTime * 10f);
    }
}