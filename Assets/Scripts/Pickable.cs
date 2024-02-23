using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Pickable : MonoBehaviour
{
    [SerializeField] private UnityEvent<PlayerManager> _onInteract;
    [SerializeField] private UnityEvent<PlayerManager> _onPick;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    public void Interact(PlayerManager playerManager)
    {
        _onInteract.Invoke(playerManager);
    }

    public void Pick(PlayerManager playerManager)
    {
        _rb.isKinematic = true;
        
        _onPick.Invoke(playerManager);

        if (playerManager.TryGetReference<PlayerHand>(out var playerHand))
        {
            playerHand.TryPickObject(transform);
        }
    }
}
