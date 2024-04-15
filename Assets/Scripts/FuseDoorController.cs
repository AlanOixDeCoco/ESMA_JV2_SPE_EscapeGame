using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FuseDoorController : MonoBehaviour
{
    [SerializeField] private int _screwsCount = 4;

    [SerializeField] private UnityEvent _onNoScrews;
    
    public void RemoveScrew()
    {
        _screwsCount--;
        if(_screwsCount <= 0) _onNoScrews.Invoke();
    }
}
