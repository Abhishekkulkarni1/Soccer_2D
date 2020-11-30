using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Puk : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float force = 0.2f;
    private bool collided = false;
    private Vector3 currentTransformVector;
    private bool raket = false;
    private bool fresh = true; //is the Puk fresh or slow? add some juice


    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody != null)
        {
            collided = true;
            raket = collision.gameObject.CompareTag("Player");
            if (!raket)
            {
                raket = collision.gameObject.CompareTag("Enemy");
            }
        }
    }

    
    void FixedUpdate()
    {
        if (collided && raket && fresh)
        {
            currentTransformVector = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            rigidBody.AddForce(currentTransformVector.normalized*force, ForceMode.Impulse);
            collided = false;
            raket = false;
            fresh = false;
            print("boosted!!");
        }
    }
}
