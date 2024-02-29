using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

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
    [FormerlySerializedAs("_playerHead")] [SerializeField] private Transform _playerHeadTransform;
    [FormerlySerializedAs("_playerHand")] [SerializeField] private Transform _playerHandTransform;

    private static PlayerManager _instance;

    public static PlayerManager Instance => _instance;

    public Transform PlayerHeadTransform => _playerHeadTransform;

    public Transform PlayerHandTransform => _playerHandTransform;

    public PlayerHand PlayerHand { get; private set; }
    
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

    private void Start()
    {
        PlayerHand = GetComponent<PlayerHand>();
    }
}
