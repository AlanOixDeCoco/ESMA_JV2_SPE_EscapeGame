using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SceneLoadedTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent _onSceneAwake, _onSceneStart;

    private void Awake()
    {
        _onSceneAwake.Invoke();
    }

    private void Start()
    {
        _onSceneStart.Invoke();
    }
}
