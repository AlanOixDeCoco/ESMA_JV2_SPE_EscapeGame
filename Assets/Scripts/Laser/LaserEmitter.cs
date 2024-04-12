using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(LineRenderer))]
public class LaserEmitter : MonoBehaviour
{
    [Header("Laser properties")] 
    [SerializeField] private byte _maxLaserBouces = 10;
    
    [SerializeField] private UnityEvent _onPlayerContact;
    
    private LineRenderer _lineRenderer;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void FixedUpdate()
    {
        UpdateLaser();
    }

    private void UpdateLaser()
    {
        var hitPoints = new List<Vector3>();
        
        var lastHitPoint = transform.position;
        var lastHitNormal = transform.forward;
        
        hitPoints.Add(lastHitPoint);

        int laserBouces = 0;
        while (laserBouces < _maxLaserBouces)
        {
            bool endLaser = true;
            
            var ray = new Ray(lastHitPoint, lastHitNormal);
            if (Physics.Raycast(ray, out var raycastHit, 100f))
            {
                lastHitPoint = raycastHit.point;
                hitPoints.Add(lastHitPoint);
                
                lastHitNormal = raycastHit.normal;

                if (raycastHit.transform.TryGetComponent<LaserMirror>(out var laserMirror))
                {
                    endLaser = false;
                }
                if (raycastHit.transform.TryGetComponent<LaserReceiver>(out var laserReceiver))
                {
                    laserReceiver.ReceiveLaser();
                }

                if (raycastHit.transform.CompareTag("Player"))
                {
                    _onPlayerContact.Invoke();
                }

                if (endLaser) break;

                laserBouces++;
            }
        }

        for (int i = 1; i < hitPoints.Count; i++)
        {
            _lineRenderer.positionCount = hitPoints.Count;
            _lineRenderer.SetPositions(hitPoints.ToArray());
        }
    }
}
