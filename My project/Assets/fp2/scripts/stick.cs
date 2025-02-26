using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stick : MonoBehaviour
{
    public int damage;

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

        //checks if enemy is hit
        if(collision.gameObject.GetComponent<BasicEnemy>() !=null)
        {
            BasicEnemy enemy = collision.gameObject.GetComponent<BasicEnemy>();

            enemy.TakeDamage(damage);

            Destroy(gameObject);
        }

        rb.isKinematic = true;

        transform.SetParent(collision.transform);
    }
}
