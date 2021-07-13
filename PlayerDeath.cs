using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public bool reseting;
    // Start is called before the first frame update
    void Start()
    {
        reseting = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Death()
    {
        FindObjectOfType<AudioManager>().Play("Lose");

        FindObjectOfType<AudioManager>().Play("Death");

        gameObject.GetComponent<Move>().dead = true;
        gameObject.GetComponent<Move>().canMove = false;
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;

        //gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<TrailRenderer>().enabled = false;
            StartCoroutine(Reset());
        if (reseting == false)
        {
            //exp
        }
    }

    IEnumerator Reset()
    {

        reseting = true;
        yield return new WaitForSeconds(2);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Debug.Log("LoadedScene");
        yield break;

    }
}
