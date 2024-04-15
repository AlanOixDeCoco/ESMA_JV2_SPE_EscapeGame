using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentOpening : MonoBehaviour
{
    public GameObject spray;

    public void OpenVent()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.useGravity = true;

        spray.transform.position = this.transform.position;
        spray.GetComponent<Rigidbody>().useGravity = true;
    }
}
