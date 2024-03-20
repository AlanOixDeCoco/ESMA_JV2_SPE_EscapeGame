using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _playerCharacterPrefab;
    [SerializeField] private GameObject _fpsCameraPrefab;
    
    private PlayerManager _playerManager;
    
    public void SpawnPlayer()
    {
        // Instanciate player
        var player = Instantiate(_playerCharacterPrefab, transform.position, transform.rotation);
        _playerManager = player.GetComponent<PlayerManager>();
        
        // And its camera, then affect it the instanced player
        var fpsCamera = Instantiate(_fpsCameraPrefab);
        fpsCamera.GetComponent<FPSCamera>().Setup(_playerManager);
    }
}
