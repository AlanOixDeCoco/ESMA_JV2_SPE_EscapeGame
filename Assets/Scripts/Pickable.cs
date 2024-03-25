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

    [SerializeField] private string _pickableTag;

    private Rigidbody _rb;

    public string PickableTag => _pickableTag;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();

        // Ensure pickable is using the right collision detection mode
        _rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }
    
    public void Interact(PlayerManager playerManager)
    {
        _onInteract.Invoke(playerManager);
    }

    public void Pick(PlayerManager playerManager)
    {
        _rb.isKinematic = true;
        
        _onPick.Invoke(playerManager);

        if (playerManager.TryGetComponent<PlayerHand>(out var playerHand))
        {
            playerHand.TryPickObject(transform);
        }
    }
}
