using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventBridge : MonoBehaviour
{
    [SerializeField] private UnityEvent _onEventTrigger;
    
    public void TriggerEvent()
    {
        _onEventTrigger.Invoke();
    }
}
