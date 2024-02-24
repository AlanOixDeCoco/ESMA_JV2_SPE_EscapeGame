using System;
using UnityEngine;

public abstract class LookState
{
    protected PlayerManager _playerManager;
    protected PlayerLook _playerLook;
    
    public LookState(PlayerLook playerLook)
    {
        _playerManager = PlayerManager.Instance;
        _playerLook = playerLook;
    }
    
    public abstract void OnEnterState();
    public abstract void OnTick();
    public abstract void OnInteract();
}

public class DefaultLookState : LookState
{
    public DefaultLookState(PlayerLook playerLook) : base(playerLook) { }
    
    public override void OnEnterState()
    {
        UIManager.Instance.SetCrosshair(CrosshairModes.Dot);
    }

    public override void OnTick()
    {
        // If aiming at nothing
        if (!_playerLook.AimingAtObject) return;
        
        // If aiming at interactable
        if (_playerLook.AimObject.TryGetComponent<Interactable>(out var interactable))
        {
            if(interactable.enabled) _playerLook.SwitchLookState(new InteractableLookState(_playerLook, interactable));
        }
        
        // If aiming at pickable
        if (_playerLook.AimObject.TryGetComponent<Pickable>(out var pickable))
        {
            if(pickable.enabled) _playerLook.SwitchLookState(new PickableLookState(_playerLook, pickable));
        }
    }

    public override void OnInteract()
    {
        Debug.Log("Nothing to interact with!");
    }
}

public class InteractableLookState : LookState
{
    private Interactable _aimedInteractable;
    
    public InteractableLookState(PlayerLook playerLook, Interactable interactable) : base(playerLook)
    {
        _aimedInteractable = interactable;
    }

    public override void OnEnterState()
    {
        UIManager.Instance.SetCrosshair(CrosshairModes.Interact);
    }

    public override void OnTick()
    {
        // If aiming at nothing
        if (!_playerLook.AimingAtObject || (_playerLook.AimObject.transform != _aimedInteractable.transform))
        {
            _playerLook.SwitchLookState(new DefaultLookState(_playerLook));
            return;
        }
        
        // Manage interaction possibility
    }

    public override void OnInteract()
    {
        _aimedInteractable.Interact(_playerManager);
    }
}

public class PickableLookState : LookState
{
    private Pickable _aimedPickable;
    
    public PickableLookState(PlayerLook playerLook, Pickable pickable) : base(playerLook)
    {
        _aimedPickable = pickable;
    }

    public override void OnEnterState()
    {
        UIManager.Instance.SetCrosshair(CrosshairModes.Pick);
    }

    public override void OnTick()
    {
        // If aiming at nothing
        if (!_playerLook.AimingAtObject || (_playerLook.AimObject.transform != _aimedPickable.transform))
        {
            _playerLook.SwitchLookState(new DefaultLookState(_playerLook));
            return;
        }
        
        // Manage picking possibility
    }

    public override void OnInteract()
    {
        _aimedPickable.Pick(_playerManager);
    }
}