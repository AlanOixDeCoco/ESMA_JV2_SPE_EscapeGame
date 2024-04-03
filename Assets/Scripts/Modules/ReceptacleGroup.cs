using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReceptacleGroup : MonoBehaviour
{
    [SerializeField] private bool _childrenAsReceptacles = true;
    [SerializeField] private Receptacle[] _receptacles;
    
    [SerializeField] private UnityEvent<bool> _onGroupChange;
    [SerializeField] private UnityEvent _onGroupTrue, _onGroupFalse;
    
    private bool _groupState = false;

    public bool GroupState => _groupState;

    private void OnEnable()
    {
        if (_childrenAsReceptacles)
        {
            _receptacles = GetComponentsInChildren<Receptacle>();
        }
        
        foreach (var receptacle in _receptacles)
        {
            receptacle.OnReceptacleChange.AddListener(RefreshGroup);
        }
        
        RefreshGroup(true);
    }

    private void OnDisable()
    {
        foreach (var receptacle in _receptacles)
        {
            receptacle.OnReceptacleChange.RemoveListener(RefreshGroup);
        }
    }

    public void RefreshGroup(bool state)
    {
        if (!state)
        {
            _groupState = false;
            _onGroupChange.Invoke(_groupState);
            _onGroupFalse.Invoke();
            return;
        }
        
        foreach (var receptacle in _receptacles)
        {
            if (!receptacle.ReceptacleState)
            {
                _groupState = false;
                _onGroupChange.Invoke(_groupState);
                _onGroupFalse.Invoke();
                return;
            }
        }
        _groupState = true;
        _onGroupChange.Invoke(_groupState);
        _onGroupTrue.Invoke();
    }
}
