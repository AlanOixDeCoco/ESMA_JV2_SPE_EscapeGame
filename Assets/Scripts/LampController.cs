using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LampController : MonoBehaviour
{
    [Header("Light Variation")]
    [SerializeField] private bool _enableVariation = false;
    [SerializeField] private float _variationFrequency = 0.5f;
    [SerializeField] private float _variationStrength = 0.5f;

    private Light _light;
    private float _defaultLightIntensity;
    
    private void Awake()
    {
        _light = GetComponentInChildren<Light>();
        _defaultLightIntensity = _light.intensity;
        
        StartCoroutine(VariateLight());
    }

    private IEnumerator VariateLight()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0, _variationFrequency));
            if(_enableVariation) _light.intensity = _defaultLightIntensity + Random.Range(-_variationStrength/2, _variationStrength/2);
        }
    }
}
