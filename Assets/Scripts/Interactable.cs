using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] private UnityEvent<PlayerManager> _onInteract;
    
    public void Interact(PlayerManager playerManager)
    {
        _onInteract.Invoke(playerManager);
    }
}