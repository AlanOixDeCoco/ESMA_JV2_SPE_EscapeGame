using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerComponent : MonoBehaviour{}

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerComponent[] _componentsReferences;

    public bool TryGetReference<T>(out T reference) where T : PlayerComponent
    {
        foreach (var component in _componentsReferences)
        {
            if (component.GetType() == typeof(T))
            {
                reference = (T)component;
                return true;
            }
        }
        reference = null;
        return false;
    }
}
