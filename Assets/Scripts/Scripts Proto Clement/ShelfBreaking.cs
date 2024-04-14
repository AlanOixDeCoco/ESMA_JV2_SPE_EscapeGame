using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfBreaking : MonoBehaviour
{
    public Rigidbody shelfRb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        shelfRb.useGravity = true;
    }

}
