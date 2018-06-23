using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float Speed = .1f;
    public float JumpForce = 0f;
    public float MaxJumpForce = .2f;
    private float[] JumpNum = new float[] {.07f, .05f, .05f, .04f, .04f, .03f}; //[6/16/18]might be able to get rid of this w/ arc math?
    public int JumpMax = 0; //[6/16/18]this is here to keep the player from just teleporting to jump height //[6/23/18] this is maybe fixed so that i don't need this anymore?
    //private bool RunTrue = false;
    private float Doot = 0f; //[6/23/18]this will change to a number when player is running (also change to private once you have the info)
    public float Slow = .01f;
    public float DeltaDoot = .1f;
    public float RunSpeed = .02f;


    private void Jump()
    {
        if (JumpMax <= 6)
        {
            JumpForce = + JumpNum[JumpMax];
        transform.position += new Vector3(Doot, JumpForce, 0f);
            JumpMax++;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("MoveRight") == true)
        {
            //Moves (the player) right
            transform.position += new Vector3(Speed, 0f, 0f);
            Doot = DeltaDoot;

        }
        if (Input.GetButton("MoveLeft") == true)
        {
            //Moves (the player) lift
            transform.position += new Vector3(-Speed, 0f, 0f);
            Doot = -DeltaDoot;
        }
        if(Input.GetButton("MoveRight") == false && Input.GetButton("MoveLeft") == false)
        {
            Doot = 0f;
        }
        /*       if (Input.GetButton("Jump") == true || JumpMax > 0)
               {
                   if (JumpMax <= 5)
                   {
                       transform.position += new Vector3(Doot, JumpForce, 0f);

                   }

                   } */
        if (Input.GetButtonDown("Jump") == true)
        {

            if (JumpMax <= 6)
            {
                JumpForce = +JumpNum[JumpMax]; //CHANGE TO THE THING FROM RUN????
                transform.position += new Vector3(Doot, JumpForce, 0f);
                JumpMax++;
            }
            if (JumpMax == 6) { JumpMax = 0; }
        }

        if (Input.GetButton("Run") == true && Speed <= .15f)
            {
                Speed = Speed + RunSpeed;
                //Doot = .01f;
            }
        if (Input.GetButton("Run") == false)
            {
                if (Speed > .1f)
                {
                    Speed = Mathf.Max(Speed - Slow * Time.deltaTime, .1f); 
                    //Doot = 0f;
                }

        }

    }
}
