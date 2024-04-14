using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{ 
    public bool doorIsOpening = false;

    private void Update()
    {

    }

    public void OpenDoor()
    {
        doorIsOpening = true;
    }
}
