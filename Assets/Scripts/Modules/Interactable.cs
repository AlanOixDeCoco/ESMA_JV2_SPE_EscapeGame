using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Interactable : MonoBehaviour
{
    [FormerlySerializedAs("_interactableRequiredPickable")] [SerializeField] private Transform _requiredPickable;
    
    [FormerlySerializedAs("_onPickableInteract")] [SerializeField] private UnityEvent<PlayerManager, Pickable> _onInteract;

    private bool _requirePickable;

    public bool RequirePickable => _requirePickable;

    private void Start()
    {
        _requirePickable = _requiredPickable != null;
    }

    public void Interact(PlayerManager playerManager, Pickable pickable)
    {
        _onInteract.Invoke(playerManager, pickable);
    }

    public bool FitsInteraction(Transform pickable)
    {
        if (!_requirePickable) return true;
        if (pickable == null) return false;
        if (_requiredPickable.name == pickable.name) return true;
        return false;
    }
}