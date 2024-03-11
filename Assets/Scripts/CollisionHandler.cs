using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent _onCollisionEnter;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if(_rb.velocity.magnitude > 0.1f) _onCollisionEnter.Invoke();
    }
}
