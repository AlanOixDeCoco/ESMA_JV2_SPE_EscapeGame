using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerInspect : PlayerComponent
{
    [SerializeField] private Transform _handTransform;
    [SerializeField] private float _rotationSpeed = 90f;

    private InputManager _inputManager;
    private Transform _pickableTransform;
    private Transform _pickableParent;
    private bool _hasPickable = false;

    private float _handRotation = 0;
    private float _pickableRotation = 0;

    private float _defaultHandRotation;

    private void Start()
    {
        _inputManager = InputManager.Instance;

        _inputManager.PlayerInputs.FPS_Gameplay.Drop.started += DropObject;
        
        _defaultHandRotation = _handTransform.localEulerAngles.x;
    }

    private void Update()
    {
        if(_hasPickable) ProcessInspect(_inputManager.PlayerInputs.FPS_Gameplay.Inspect.ReadValue<Vector2>());
    }

    public bool TryPickObject(Transform pickable)
    {
        if (_hasPickable) return false;
        
        _handRotation = _defaultHandRotation - 90f;
        _pickableRotation = 0f;
        
        _pickableTransform = pickable;
        _pickableParent = _pickableTransform.parent;
        _pickableTransform.SetParent(_handTransform);
        _pickableTransform.localPosition = Vector3.zero;
        
        _hasPickable = true;

        return true;
    }

    public void DropObject(InputAction.CallbackContext context)
    {
        if (_pickableTransform != null)
        {
            _hasPickable = false;
            
            _pickableTransform.parent = _pickableParent;
            
            var pickableRb = _pickableTransform.GetComponent<Rigidbody>();
            pickableRb.isKinematic = false;
            pickableRb.velocity = GetComponent<CharacterController>().velocity;
        
            _pickableTransform = null;
        }
    }
    
    private void ProcessInspect(Vector2 input)
    {
        _handTransform.localEulerAngles = Vector3.right * _handRotation;
        _pickableTransform.localEulerAngles = Vector3.forward * _pickableRotation;

        _handRotation += input.y * _rotationSpeed * Time.deltaTime;
        _pickableRotation += -input.x * _rotationSpeed * Time.deltaTime;

        _handRotation = Mathf.Clamp(_handRotation, -160f - 90f, 160 - 90f);
        _pickableRotation = Mathf.Clamp(_pickableRotation, -160f, 160);
    }
}
