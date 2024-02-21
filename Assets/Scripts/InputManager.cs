using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;
    
    private PlayerInputs _playerInputs;

    public static InputManager Instance => _instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        
        _playerInputs = new PlayerInputs();
    }

    private void OnEnable()
    {
        _playerInputs.Enable();
    }

    private void OnDisable()
    {
        _playerInputs.Disable();
    }

    public Vector2 GetPlayerMovement()
    {
        return _playerInputs.FPS_Gameplay.Movement.ReadValue<Vector2>();
    }
    
    public Vector2 GetPlayerLook()
    {
        return _playerInputs.FPS_Gameplay.Look.ReadValue<Vector2>();
    }

    public bool PlayerJumpedThisFrame()
    {
        return _playerInputs.FPS_Gameplay.Jump.triggered;
    }
}
