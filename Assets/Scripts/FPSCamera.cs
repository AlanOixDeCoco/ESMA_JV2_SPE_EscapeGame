using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    private CinemachineVirtualCamera _virtualCamera;
    
    private void Awake()
    {
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void Setup(PlayerManager playerManager)
    {
        _virtualCamera.Follow = playerManager.PlayerHeadTransform;
        
        var povTransposer = _virtualCamera.GetCinemachineComponent<CinemachinePOV>();
        povTransposer.m_HorizontalAxis.Value = playerManager.PlayerHeadTransform.eulerAngles.y;
    }
}
