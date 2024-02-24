using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    private CinemachineVirtualCamera _virtualCamera;
    
    private void Start()
    {
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();

        _virtualCamera.Follow = PlayerManager.Instance.PlayerHead;
    }
}
