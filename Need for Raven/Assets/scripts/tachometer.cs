using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tachometer : MonoBehaviour
{
    private Rigidbody rb;
    public float maxSpeed = 360f;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        speed = CarSpeed();
    }

    public float CarSpeed()
    {
        float speed = rb.velocity.magnitude;
        speed *= 3.6f;
        if (speed > maxSpeed)
        {
            rb.velocity = (maxSpeed / 3.6f) * rb.velocity.normalized;
        }
        return speed;
    }
}
