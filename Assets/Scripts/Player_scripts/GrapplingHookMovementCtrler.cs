using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GrapplingHookMovementCtrler : MonoBehaviour {

    public Rigidbody2D GrappleBody;
    public float GrappleForceX = 8f;
    private Vector3 Origin;
    private float DeltaMove;
    object Grapplehook = GameObject.Find("Grapplehook");
 
    private void Start()
    {
        
    }


    // Update is called once per frame
    void Update () {

        if (Input.GetButtonDown("Grapple"))
        {
          //  Origin = Grapplehook.transform.position;
            GrappleBody.AddForce(new Vector3(GrappleForceX, 0f, 0f));
        }

        /*what I need to do, in psudo-code:
         when(buttonpressed) {
         grapplehook goes to place. 
        }
        if(runs into interactable thing){
       Stop + bring [player] to collision area 
        }*/
    }
}
