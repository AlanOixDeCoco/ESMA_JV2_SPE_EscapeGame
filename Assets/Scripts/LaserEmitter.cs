using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserEmitter : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    
    private LineRenderer _lineRenderer;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        UpdateLaser();
    }

    private void UpdateLaser()
    {
        var hitPoints = new List<Vector3>();
        
        var lastHitPoint = transform.position;
        var lastHitNormal = transform.forward;
        
        hitPoints.Add(lastHitPoint);
        
        var endLaser = false;
        while (!endLaser)
        {
            endLaser = true;
            var ray = new Ray(lastHitPoint, lastHitNormal);
            if (Physics.Raycast(ray, out var raycastHit, 100f, _layerMask))
            {
                lastHitPoint = raycastHit.point;
                hitPoints.Add(lastHitPoint);
                
                lastHitNormal = raycastHit.normal;

                if (raycastHit.transform.TryGetComponent<LaserMirror>(out var laserMirror)) endLaser = false;
            }
        }

        for (int i = 1; i < hitPoints.Count; i++)
        {
            _lineRenderer.positionCount = hitPoints.Count;
            _lineRenderer.SetPositions(hitPoints.ToArray());
        }
    }
}
