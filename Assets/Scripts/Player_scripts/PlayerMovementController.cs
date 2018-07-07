using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float Speed = .1f;
    public float JumpForce = 500f;
    private float JumpMax = 0f; //[6/16/18]this is here to keep the player from just teleporting to jump height //[6/23/18] this is maybe fixed so that i don't need this anymore? //[7/7/18] the same as the last one but really this time?
    public float Slow = .01f;
    public float RunSpeed = .02f;
    public Rigidbody2D RigidBody;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("MoveRight") == true)
        {
            //Moves (the player) right
            transform.position += new Vector3(Speed, 0f, 0f);

        }
        if (Input.GetButton("MoveLeft") == true)
        {
            //Moves (the player) left
            transform.position += new Vector3(-Speed, 0f, 0f);
        }

        if (Input.GetButtonDown("Jump") == true)
        {
            RigidBody.AddForce(new Vector3(0f, JumpForce, 0f));
        }

        if (Input.GetButton("Run") == true && Speed <= .15f)
            {
                Speed = Speed + RunSpeed;
            }
        if (Input.GetButton("Run") == false)
            {
                if (Speed > .1f)
                {
                    Speed = Mathf.Max(Speed - Slow * Time.deltaTime, .1f); 
                }

        }

    }
}
