using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 10;
    public float maxSpeed = 10;

    private Vector3 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        screenBounds = (new Vector3(30f, 0, 40));

    }

    void Update()
    {
        if (transform.position.x < -screenBounds.x * 2 || transform.position.x > screenBounds.x * 2)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(transform.forward * speed);

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

        }
    }
}
