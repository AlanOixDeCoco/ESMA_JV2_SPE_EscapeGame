using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] private UnityEvent<PlayerManager> _onInteract;
    
    private PlayerManager _playerManager;

    public void Interact()
    {
        Debug.Log($"Interact!");
        _onInteract.Invoke(_playerManager);
    }

    public void OnAim(PlayerManager playerManager)
    {
        _playerManager = playerManager;
        UIManager.Instance.SetCrosshair(CrosshairModes.Interact);
    }
}