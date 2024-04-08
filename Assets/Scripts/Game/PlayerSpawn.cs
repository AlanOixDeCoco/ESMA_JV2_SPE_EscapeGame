using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerSpawn : MonoBehaviour
{
    [Header("Containers")]
    [SerializeField] private Transform _gameplayTransform;
    [SerializeField] private Transform _uiTransform;
    
    [Header("Prefabs")]
    [SerializeField] private GameObject _playerCharacterPrefab;
    [SerializeField] private GameObject _fpsCameraPrefab;
    [SerializeField] private GameObject _playerUIPrefab;
    
    private PlayerManager _playerManager;

    public void SpawnPlayer()
    {
        // Instanciate player
        var player = Instantiate(_playerCharacterPrefab, transform.position, transform.rotation);
        player.transform.parent = _gameplayTransform;
        _playerManager = player.GetComponent<PlayerManager>();
        
        // And its camera, then affect it the instanced player
        var fpsCamera = Instantiate(_fpsCameraPrefab, _gameplayTransform);
        fpsCamera.GetComponent<FPSCamera>().Setup(_playerManager);
        
        // And its UI, then assign it to the player look
        var playerUI = Instantiate(_playerUIPrefab, _uiTransform);
        var playerLook = player.GetComponent<PlayerLook>();
        playerLook.SetUIReference(playerUI.GetComponent<PlayerUI>());
    }
}