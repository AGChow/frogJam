using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour
{
    public GameManager GM;
    public GameObject Sparks;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("PickUp");
            FindObjectOfType<AudioManager>().Play("Ribbit");


            Instantiate(Sparks, transform.position, transform.rotation);
            GM.Score = GM.Score + 5;
            Destroy(gameObject);
        }
    }
}
