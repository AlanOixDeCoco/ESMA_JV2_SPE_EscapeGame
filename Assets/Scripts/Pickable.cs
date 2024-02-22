using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Pickable : MonoBehaviour
{
    [SerializeField] private UnityEvent<PlayerManager> _onPick;

    private PlayerManager _playerManager;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void OnAim(PlayerManager playerManager)
    {
        _playerManager = playerManager;
        UIManager.Instance.SetCrosshair(CrosshairModes.Pick);
    }

    public void OnPick()
    {
        _rb.isKinematic = true;
        
        _onPick.Invoke(_playerManager);
    }
}
