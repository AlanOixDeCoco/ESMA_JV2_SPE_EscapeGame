using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WindowController : MonoBehaviour
{
    [SerializeField] private int _hitsToBreak = 1;

    [SerializeField] private UnityEvent _onHit;
    
    [SerializeField] private UnityEvent _onBreak;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.TryGetComponent<Pickable>(out var pickable))
        {
            _hitsToBreak--;
        }
        if(_hitsToBreak <= 0) _onBreak.Invoke();
        else _onHit.Invoke();
    }
}
