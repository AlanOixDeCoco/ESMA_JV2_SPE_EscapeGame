using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private MeshRenderer _magazineMeshRenderer;

    [SerializeField] private bool _failed = false;
    
    private void Start()
    {
        if(!_failed) return;
        
        _magazineMeshRenderer.material = GameController.Instance.CurrentSceneAndGameoverMagazine._gameoverMagazineMaterial;
    }
}
