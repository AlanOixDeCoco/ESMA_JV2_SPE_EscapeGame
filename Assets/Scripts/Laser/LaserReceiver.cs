using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LaserReceiver : MonoBehaviour
{
    [SerializeField] private UnityEvent _onReceiveLaser;
    
    public void ReceiveLaser()
    {
        _onReceiveLaser.Invoke();
    }
}
