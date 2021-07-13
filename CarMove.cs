using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CarMove : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 10;
    public float maxSpeed = 10;

    private Vector3 screenBounds;
    public GameObject explosion;


    CinemachineImpulseSource impulse;
    public float shakeIntensity;

    public GameObject GM;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameManager");
        impulse = transform.GetComponent<CinemachineImpulseSource>();

        rb = GetComponent<Rigidbody>();
        screenBounds = (new Vector3(30f, 0, 40));
        Debug.Log(screenBounds.x);
    }

    // Update is called once per frame

    void Update()
    {
        if (transform.position.x < -screenBounds.x * 2 || transform.position.x > screenBounds.x *2) 
        {
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        rb.AddForce(transform.forward * speed);

        if(rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Vehicle")
        {

            FindObjectOfType<AudioManager>().Play("Explosion");
            FindObjectOfType<AudioManager>().Play("MetalCrash");



            GM.GetComponent<GameManager>().Score = GM.GetComponent<GameManager>().Score + 100;
            ShakeScreen();
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "Monster")
        {
            FindObjectOfType<AudioManager>().Play("Explosion");
            FindObjectOfType<AudioManager>().Play("MetalCrash");


            GM.GetComponent<GameManager>().Score = GM.GetComponent<GameManager>().Score + 100;
            ShakeScreen();
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);

            
        }


    }

    public void ShakeScreen()
    {
        impulse.GenerateImpulse(shakeIntensity);
    }
}
