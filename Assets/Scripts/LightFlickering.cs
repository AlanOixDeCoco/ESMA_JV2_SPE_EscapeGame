using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlickering : MonoBehaviour
{
    public Light lampLight;

    private void Start()
    {
        lampLight.enabled = false;
    }

    public void lightOn()
    {
        lampLight.enabled = true;
    }

    public void lightOff()
    {
        lampLight.enabled = false;
    }

    public void morsePattern1()
    {
        lightOn();

        Invoke("lightOff", 2);

        Invoke("lightOn", 3);

        Invoke("lightOff", 5);

        Invoke("lightOn", 6);

        Invoke("lightOff", 6.5f);
    }

    public void morsePattern2()
    {
        lightOn();

        Invoke("lightOff", 2);

        Invoke("lightOn", 3);

        Invoke("lightOff", 5);

        Invoke("lightOn", 6);

        Invoke("lightOff", 8);
    }

    public void morsePattern3()
    {
        lightOn();

        Invoke("lightOff", 2);

        Invoke("lightOn", 3);

        Invoke("lightOff", 3.5f);
    }

    public void morsePattern4()
    {
        lightOn();

        Invoke("lightOff", 0.5f);
    }
}
