using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Receptacle : MonoBehaviour
{
    [SerializeField] private string _pickableTag;

    [SerializeField] private UnityEvent<bool> _onReceptacleChange;
    [SerializeField] private UnityEvent _onReceptacleTrue, _onReceptacleFalse;

    private bool _receptacleState;

    public bool ReceptacleState => _receptacleState;

    public UnityEvent<bool> OnReceptacleChange => _onReceptacleChange;

    private void Start()
    {
        var collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Pickable>(out var pickable))
        {
            if (pickable.PickableTag == _pickableTag)
            {
                _receptacleState = true;
                _onReceptacleChange.Invoke(_receptacleState);
                _onReceptacleTrue.Invoke();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Pickable>(out var pickable))
        {
            if (pickable.PickableTag == _pickableTag)
            {
                _receptacleState = false;
                _onReceptacleChange.Invoke(_receptacleState);
                _onReceptacleFalse.Invoke();
            }
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<Pickable>(out var pickable))
        {
            if (pickable.PickableTag == _pickableTag)
            {
                _receptacleState = true;
                _onReceptacleChange.Invoke(_receptacleState);
                _onReceptacleTrue.Invoke();
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.TryGetComponent<Pickable>(out var pickable))
        {
            if (pickable.PickableTag == _pickableTag)
            {
                _receptacleState = false;
                _onReceptacleChange.Invoke(_receptacleState);
                _onReceptacleFalse.Invoke();
            }
        }
    }
}
