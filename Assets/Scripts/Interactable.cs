using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Interactable : MonoBehaviour
{
    [FormerlySerializedAs("_interactableRequiredPickable")] [SerializeField] private Transform _requiredPickable;
    
    [SerializeField] private UnityEvent<PlayerManager> _onInteract;
    [SerializeField] private UnityEvent<PlayerManager, Pickable> _onPickableInteract;

    private bool _requirePickable;

    public bool RequirePickable => _requirePickable;

    private void Start()
    {
        _requirePickable = _requiredPickable != null;
    }

    public void Interact(PlayerManager playerManager)
    {
        _onInteract.Invoke(playerManager);
    }

    public void PickableInteract(PlayerManager playerManager, Pickable pickable)
    {
        _onPickableInteract.Invoke(playerManager, pickable);
    }

    public bool FitsInteraction(Transform pickable)
    {
        if (!_requirePickable) return true;
        if (pickable == null) return false;
        else if (_requiredPickable.name == pickable.name) return true;
        return false;
    }
}