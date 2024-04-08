using System;
using UnityEngine;

public abstract class LookState
{
    protected PlayerManager _playerManager;
    protected PlayerLook _playerLook;
    
    public LookState(PlayerManager playerManager, PlayerLook playerLook)
    {
        _playerManager = playerManager;
        _playerLook = playerLook;
    }
    
    public abstract void OnEnterState();
    public abstract void OnTick();
    public abstract void OnInteract();
}

public class DefaultLookState : LookState
{
    public DefaultLookState(PlayerManager playerManager, PlayerLook playerLook) : base(playerManager, playerLook)
    {
        _playerManager = playerManager;
        _playerLook = playerLook;
    }
    
    public override void OnEnterState()
    {
        _playerLook.PlayerUI.SetCrosshair(CrosshairModes.Dot);
    }

    public override void OnTick()
    {
        // If aiming at nothing
        if (!_playerLook.AimingAtObject) return;
        
        // If aiming at interactable
        if (_playerLook.AimObject.TryGetComponent<Interactable>(out var interactable))
        {
            if(interactable.enabled && interactable) _playerLook.SwitchLookState(new InteractableLookState(_playerManager, _playerLook, interactable));
        }
        
        // If aiming at pickable
        if (_playerLook.AimObject.TryGetComponent<Pickable>(out var pickable))
        {
            if(pickable.enabled) _playerLook.SwitchLookState(new PickableLookState(_playerManager, _playerLook, pickable));
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
    
    public InteractableLookState(PlayerManager playerManager, PlayerLook playerLook, Interactable interactable) : base(playerManager, playerLook)
    {
        _playerManager = playerManager;
        _playerLook = playerLook;
        _aimedInteractable = interactable;
    }

    public override void OnEnterState()
    {
        if (!_aimedInteractable.RequirePickable)
        {
            _playerLook.PlayerUI.SetCrosshair(CrosshairModes.Interact);
            return;
        }
        else {
            if (!_playerManager.PlayerHand.HoldPickable)
            {
                _playerLook.PlayerUI.SetCrosshair(CrosshairModes.CantInteract);
                return;
            }

            if (_aimedInteractable.FitsInteraction(_playerManager.PlayerHand.PickableTransform))
            {
                _playerLook.PlayerUI.SetCrosshair(CrosshairModes.Interact);
            }
            else
            {
                _playerLook.PlayerUI.SetCrosshair(CrosshairModes.CantInteract);
            }
        }
    }

    public override void OnTick()
    {
        // If aiming at nothing
        if (!_playerLook.AimingAtObject || (_playerLook.AimObject != _aimedInteractable.transform))
        {
            _playerLook.SwitchLookState(new DefaultLookState(_playerManager, _playerLook));
            return;
        }
    }

    public override void OnInteract()
    {
        if (_aimedInteractable.FitsInteraction(_playerManager.PlayerHand.PickableTransform))
        {
            _aimedInteractable.Interact(_playerManager, _playerManager.PlayerHand.Pickable);
        }
    }
}

public class PickableLookState : LookState
{
    private Pickable _aimedPickable;
    
    public PickableLookState(PlayerManager playerManager, PlayerLook playerLook, Pickable pickable) : base(playerManager, playerLook)
    {
        _playerManager = playerManager;
        _playerLook = playerLook;
        _aimedPickable = pickable;
    }

    public override void OnEnterState()
    {
        _playerLook.PlayerUI.SetCrosshair(CrosshairModes.Pick);
    }

    public override void OnTick()
    {
        // If aiming at nothing
        if (!_playerLook.AimingAtObject || (_playerLook.AimObject != _aimedPickable.transform))
        {
            _playerLook.SwitchLookState(new DefaultLookState(_playerManager, _playerLook));
            return;
        }
        
        // Manage picking possibility
        if(_playerManager.PlayerHand.HoldPickable) UIManager.Instance.SetCrosshair(CrosshairModes.CantPick);
        else _playerLook.PlayerUI.SetCrosshair(CrosshairModes.Pick);
    }

    public override void OnInteract()
    {
        _aimedPickable.Pick(_playerManager);
    }
}