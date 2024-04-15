using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{ 
    public bool doorIsOpening = false;

    public float openingFactor = 0;
    public float maxOpening = 0.65f;

    private void Start()
    {
        print("The door is Rusty and cannot open completely");
    }
    private void Update()
    {
        if (doorIsOpening == true && openingFactor <= maxOpening)
        {
            transform.position += new Vector3(0.001f,0,0);
            openingFactor += 0.001f;
        }
        else
        {
            print("cant open the door more");
            transform.position += new Vector3(0, 0, 0);
        }
    }

    public void OpenDoor()
    {
        doorIsOpening = true;
    }

    public void cleanDoor()
    {
        print("The door can now be oppened completely");
        maxOpening = 1.4f;
    }
}
