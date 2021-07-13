using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 10;
    public Vector3 movement;
    public Rigidbody rb;

    public bool canMove;
    public bool dead;
    public bool celebrating;


    public Animator animator;
    public string newState;
    private string CurrentState;

    public GameObject frogModel;

    public Vector3 scale;
    public float growthFactor;


    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponentInChildren<Animator>();

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));




        //animationstate conditions

        AnimatorStateInfo animationState = animator.GetCurrentAnimatorStateInfo(0);

        if (dead == false)
        {
            if(celebrating == false && canMove == true)
            {
            if(Input.GetAxisRaw("Horizontal") > 0)
            {
                    frogModel.transform.rotation = Quaternion.Euler(0, 90, 0);
                    JumpState();
            }
            else if(Input.GetAxisRaw("Horizontal") < 0)
            {
                    frogModel.transform.rotation = Quaternion.Euler(0, -90, 0);

                    JumpState();
            }
            else if (Input.GetAxisRaw("Vertical") > 0)
                {
                    frogModel.transform.rotation = Quaternion.Euler(0, 0, 0);

                    JumpState();
                }
            else if (Input.GetAxisRaw("Vertical") < 0)
                {
                    frogModel.transform.rotation = Quaternion.Euler(0, 180, 0);

                    JumpState();
                }



                else if(Input.GetAxisRaw("Vertical") == 0 & Input.GetAxisRaw("Horizontal") == 0)
            {
                IdleState();
            }
            }
            else if (celebrating == true)
            {
                Celebrate();
            }
        }
        else if(dead == true)
        {
            DeathAnimation();
        }
    

    }

    private void FixedUpdate()
    {
        if(canMove == true)
        {

          MoveCharacter(movement);
        }
    }

    void MoveCharacter(Vector3 direction)
    {
        rb.MovePosition(transform.position + (direction * speed * Time.deltaTime));
    }



    //Animations
    public void ChangeAnimationState(string newState)
    {
        if (CurrentState == newState)
        { return; }
        animator.Play(newState);
        CurrentState = newState;
    }



    public void Celebrate()
    {
        ChangeAnimationState("Celebrate");
        frogModel.transform.rotation = Quaternion.Euler(0, 180, 0);

    }

    public void DeathAnimation()
    {
        ChangeAnimationState("Death");

    }

    public void IdleState()
    {
        ChangeAnimationState("Idle");

    }

    public void JumpState()
    {
        ChangeAnimationState("Jump");

    }




    public void PowerUp()
    {
        scale = new Vector3(growthFactor, growthFactor, growthFactor);
        gameObject.transform.localScale = scale;
        gameObject.tag = ("Monster");
    }


}



