using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    private PlayerManager _playerManager;
    
    public void OnAim(PlayerManager playerManager)
    {
        _playerManager = playerManager;
        UIManager.Instance.SetCrosshair(CrosshairModes.Pick);
    }
}
