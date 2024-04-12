using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent<Collision> _onCollisionEnter;
    [SerializeField] private UnityEvent<Collider> _onTriggerEnter;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        _onCollisionEnter.Invoke(other);
    }

    private void OnTriggerEnter(Collider other)
    {
        _onTriggerEnter.Invoke(other);
    }
}
