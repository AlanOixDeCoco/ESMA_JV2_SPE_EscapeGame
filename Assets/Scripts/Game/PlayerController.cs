using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInputs _playerInputs;
    public PlayerInputs PlayerInputs => _playerInputs;
    
    private void Awake()
    {
        _playerInputs = new PlayerInputs();
        _playerInputs.Enable();
    }

    private void OnEnable()
    {
        _playerInputs.Enable();
    }

    private void OnDisable()
    {
        _playerInputs.Disable();
    }
}
