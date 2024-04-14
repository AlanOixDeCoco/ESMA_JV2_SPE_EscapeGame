using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    [Header("Time")] 
    [SerializeField] private TextMeshProUGUI _timeText;

    private void Update()
    {
        SetRemainingTime();
    }

    public void SetCrosshair(CrosshairModes mode)
    {
        foreach (var crosshair in _crosshairs)
        {
            if (crosshair._mode == mode) _crosshairImg.sprite = crosshair._sprite;
        }
    }

    public void SetRemainingTime()
    {
        var remainingTime = GameController.Instance.TimeController.GetRemainingTime();
        var seconds = (int)(remainingTime % 60);
        var minutes = (int)((remainingTime - seconds) / 60);

        _timeText.text = $"{minutes}:{seconds}";
    }
}
