using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StateManager : MonoBehaviour
{
    [Header("State")]
    [SerializeField] private bool _defaultState = false;

    [Header("Events")]
    [SerializeField] private UnityEvent<bool> _onStateChange;
    [SerializeField] private UnityEvent _onStateOn;
    [SerializeField] private UnityEvent _onStateOff;
    
    private bool _state;

    private void Start()
    {
        _state = _defaultState;
        SetState(_state);
    }

    public void SetState(bool state)
    {
        _state = state;
        _onStateChange.Invoke(_state);
        if(_state) _onStateOn.Invoke();
        else _onStateOff.Invoke();
    }

    public void ToggleState()
    {
        SetState(!_state);
    }
}
