using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
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
    
    [Header("Helper UI")]
    [SerializeField] private RectTransform[] _helperUIs;
    
    private void Start()
    {
        HideUIHelper();
        GameController.Instance.PlayerController.PlayerInputs.FPS_UI.Escape.performed += ToggleUIHelper;
    }

    private void OnDisable()
    {
        GameController.Instance.PlayerController.PlayerInputs.FPS_UI.Escape.performed -= ToggleUIHelper;
    }

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

        _timeText.text = $"{minutes:00}:{seconds:00}";
    }
    
    private void HideUIHelper()
    {
        foreach (var ui in _helperUIs)
        {
            ui.gameObject.SetActive(false);
        }
    }
    
    private void ToggleUIHelper(InputAction.CallbackContext callbackContext)
    {
        foreach (var ui in _helperUIs)
        {
            ui.gameObject.SetActive(!ui.gameObject.activeSelf);
        }
    }
}
