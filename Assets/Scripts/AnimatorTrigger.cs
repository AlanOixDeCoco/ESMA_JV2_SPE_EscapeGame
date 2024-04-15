using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimatorTrigger : MonoBehaviour
{
    private Animator _animator;

    [SerializeField] private UnityEvent _onAnimationEnd;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void TriggerAnimationEnd()
    {
        _onAnimationEnd.Invoke();
    }
}
