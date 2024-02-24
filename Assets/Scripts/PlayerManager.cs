using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
public abstract class PlayerComponent : MonoBehaviour
{
    protected PlayerManager _playerManager;

    private void Awake()
    {
        _playerManager = GetComponent<PlayerManager>();
    }
}

public class PlayerManager : MonoBehaviour
{
    // EDITOR VARIABLES
    [Header("Player References")]
    [SerializeField] private Transform _playerHead;
    [SerializeField] private Transform _playerHand;

    private static PlayerManager _instance;

    public static PlayerManager Instance => _instance;

    public Transform PlayerHead => _playerHead;

    public Transform PlayerHand => _playerHand;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
}
