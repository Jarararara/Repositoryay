using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stick : MonoBehaviour
{
    private Rigidbody rb;

    private bool targetHit;

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (targetHit)
            return;
        else 
            targetHit = true;

        rb.isKinematic = true;

        transform.SetParent(collision.transform);
    }
}
