using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pullable : MonoBehaviour
{
    [SerializeField] private Transform _centerOfMass;
    
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void OnPull(PlayerManager playerManager, Pickable pickable)
    {
        var playerHandTransform = playerManager.PlayerHandTransform;

        var forceDir = playerHandTransform.position - _centerOfMass.position;
        forceDir.y = 0;
        
        _rb.AddForce(forceDir * 1500);
    }
}
