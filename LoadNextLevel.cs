using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    public GameManager gm;
    public GameObject celebrationParticles;
    public bool lastLevel;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();  
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Monster")
        {
            FindObjectOfType<AudioManager>().Play("Win");
            FindObjectOfType<AudioManager>().Play("Fireworks");
            FindObjectOfType<AudioManager>().Play("Ribbits");
            FindObjectOfType<AudioManager>().VolumeAdjust("Theme", 0);


            gm.Cam3Activate();


            other.gameObject.transform.position = this.gameObject.transform.position;
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            other.gameObject.GetComponent<Move>().canMove = false;
            other.gameObject.GetComponent<Move>().celebrating = true;

            Instantiate(celebrationParticles, transform.position, transform.rotation);
            StartCoroutine(LoadLevel());
        }
    }

    IEnumerator LoadLevel()
    {

        // load the next level
        if(lastLevel == false)
        {
        yield return new WaitForSeconds(5);
        FindObjectOfType<AudioManager>().VolumeAdjust("Theme", 0.3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            gm.WinScreen();
        }

    }
}
