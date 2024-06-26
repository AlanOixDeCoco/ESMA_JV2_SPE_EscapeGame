using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public enum CrosshairModes
{
    Dot,
    Interact,
    CantInteract,
    Pick,
    CantPick
}

[Serializable]
public class Crosshair
{
    public CrosshairModes _mode;
    public Sprite _sprite;
}

public class PlayerUI : MonoBehaviour
{
    [Header("Crosshair")] 
    [SerializeField] private Crosshair[] _crosshairs;
    [SerializeField] private Image _crosshairImg;
    
    public void SetCrosshair(CrosshairModes mode)
    {
        foreach (var crosshair in _crosshairs)
        {
            if (crosshair._mode == mode) _crosshairImg.sprite = crosshair._sprite;
        }
    }
}
