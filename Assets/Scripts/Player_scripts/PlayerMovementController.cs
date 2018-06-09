using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour {

    // Update is called once per frame
    void Update () {
       
        if (Input.GetButton("MoveRight") == true)
        {
            Debug.Log("move right");
            //Moves (the player) right
            transform.position += new Vector3(.5f,0f,0f);
        }
        if (Input.GetButton("MoveLeft") == true)
        {
            Debug.Log("move left");
            //Moves (the player) right
            transform.position += new Vector3(-.5f, 0f, 0f);
        }
    }
}
