using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour, IInteractable
{
    [SerializeField] private ScriptableObject _pickableSO;
    
    private PlayerManager _playerManager;

    public void Interact()
    {
        Debug.Log("Interact with: " + gameObject.name);
    }
    
    public void OnRaycastHit(PlayerManager playerManager)
    {
        _playerManager = playerManager;
    }
}