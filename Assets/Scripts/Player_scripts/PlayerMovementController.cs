using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour {
    public float Speed = .1f;
    public float JumpForce = 5f;
    private float[] Jump = new float[] {/*fill w/ things, jump things*/ }; //might be able to get rid of this w/ arc math?
    public int JumpMax = 0; //this is here to keep the player from just teleporting to jump height

    // Update is called once per frame
    void Update() {
        if (Input.GetButton("MoveRight") == true)
        {
            //Moves (the player) right
            transform.position += new Vector3(Speed, 0f, 0f);
        }
        if (Input.GetButton("MoveLeft") == true)
        {
            //Moves (the player) right
            transform.position += new Vector3(-Speed, 0f, 0f);
        }
        if (Input.GetButtonDown("Jump") == true || JumpMax > 0)
        { if (JumpMax <= 5) { 
            transform.position += new Vector3(0f, JumpForce/5 , 0f);
                JumpMax ++;
                
        } if (JumpMax == 5) { JumpMax = 0; }
        }
        
    if (Input.GetButton("Run") == true && Speed <= .15f)
        {
            Speed = Speed + .02f;
        }
        if (Input.GetButton("Run") == false)
        {
            if (Speed > .1f)
            {
                Speed = Mathf.Max(Speed - .01f, .1f);
            }
        }
    }

}
