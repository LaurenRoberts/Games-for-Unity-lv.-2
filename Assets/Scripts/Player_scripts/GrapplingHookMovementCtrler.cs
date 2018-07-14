using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GrapplingHookMovementCtrler : MonoBehaviour {

    public Rigidbody2D GrappleBody;
    public GameObject Grapplehook;
    public GameObject Player;
    private Vector3 Origin;
    private float DeltaMove;
    private float PositionDifference;
    public float GrappleForceX = 10f;
    public float GrappleForceY = 9f;
    public float GHslow = 5f;
    public float RopeDistance = 5f;



    private void Start()
    {
        Grapplehook = GameObject.Find("Grapplehook");
        GrappleBody = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");

    }

    private void FindPosition() {
        Vector3 Grap = Grapplehook.transform.position;
        Vector3 plyr = Player.transform.position;
        PositionDifference = Vector3.Distance(Grap, plyr);
    }

    private void FixedUpdate()
    {
        FindPosition();
        if (Input.GetButtonDown("Grapple") && PositionDifference < RopeDistance)
        {
            Origin = Grapplehook.transform.position;
            GrappleBody.AddForce(new Vector3(GrappleForceX, GrappleForceY, 0f));
            GrappleBody.drag = GHslow;
        }
        if (PositionDifference >= RopeDistance)
        {
            GrappleBody.AddForce(new Vector3(-GrappleForceX, -GrappleForceY, 0f));
            //(code)find fastest course to player and add force in that direction
            //  GrappleBody.MovePosition(Player.transform.position);
            //Move Grapplehook to Player X & Y
        }

    } 
    // Update is called once per frame
    void Update () {

        

        /*what I need to do, in psudo-code:
         when(buttonpressed) {
         grapplehook goes to place. 
        }
        if(runs into interactable thing){
       Stop + bring [player] to collision area 
        }else{go back to player}*/
    }
}
