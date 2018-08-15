using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class OrbitThing : MonoBehaviour { 



    public Rigidbody2D GrappleBody;
    public GameObject Grapplehook;
    public GameObject Player;
    private Transform Origin;
    private float DeltaMove;
    private float PositionDifference;
    public float GrappleForceX = 10f;
    public float GrappleForceY = 9f;
    public float GHslow = 5f;
    public float RopeDistance = 5f;



    private void Start()
    {
     //   Grapplehook = GameObject.Find("Grapplehook");
        GrappleBody = GetComponent<Rigidbody2D>();
       // Player = GameObject.Find("Player");

    }

    private void FindPosition()
    {
        Vector3 Grap = Grapplehook.transform.position;
        Vector3 plyr = Player.transform.position;
        PositionDifference = Vector3.Distance(Grap, plyr);
    }
    private void BackToPlayer()
    {
        float GrapX = Grapplehook.transform.position.x;
        float GrapY = Grapplehook.transform.position.y;
        float PlyrX = Player.transform.position.x;
        float PlyrY = Player.transform.position.y;
        if (GrapX < PlyrX) //if plyrX < grapX then grapplehook is to the right of player
        {
            if (GrapY < PlyrY)
            {
                //in this block Grapplehook is to the Left and below Player
                GrappleBody.AddForce(new Vector3(GrappleForceX, GrappleForceY, 0f));
            }
            if (GrapY > PlyrY)
            {
                //in this block Grapplehook is to the Left and above Player
                GrappleBody.AddForce(new Vector3(GrappleForceX, -GrappleForceY, 0f));
            }
        }
        if (GrapX > PlyrX)
        {
            if (GrapY < PlyrY)
            {
                //in this block Grapplehook is to the Right and below Player
                GrappleBody.AddForce(new Vector3(-GrappleForceX, GrappleForceY, 0f));
            }
            if (GrapY > PlyrY)
            {
                //in this block Grapplehook is to the Right and above Player
                GrappleBody.AddForce(new Vector3(-GrappleForceX, -GrappleForceY, 0f));
            }
        }
    }

    private void FixedUpdate()
    {
        FindPosition();
        Origin = Player.transform;
        if (Input.GetButtonDown("Grapple") && PositionDifference < RopeDistance) //"throws" the grapplehook. only one direction currently.
        {
            GrappleForceX = 10f;
            GrappleForceY = 9f;
            GrappleBody.AddForce(new Vector3(GrappleForceX, GrappleForceY, 0f));
            GrappleBody.drag = GHslow;
        }
        if (PositionDifference >= RopeDistance || Grapplehook.transform.position != Origin.position)
        {

            BackToPlayer();
            //add code to check if grapplehook is with player. this might be a bit weird until that
            //GrappleBody.AddForce(new Vector3(-GrappleForceX, -GrappleForceY, 0f));
            //(code)find fastest course to player and add force in that direction
            //  GrappleBody.MovePosition(Player.transform.position);
            //Move Grapplehook to Player X & Y
        }
        //if (PositionDifference < 1.5f && Grapplehook.transform.position != Origin.position) {

        //}
        //else
        //{
        //    GrappleForceX = 10f;
        //    GrappleForceY = 9f;
        //}

    }
    // Update is called once per frame
    void Update()
    {



        /*what I need to do, in psudo-code:
         when(buttonpressed) {
         grapplehook goes to place. 
        }
        if(runs into interactable thing){
       Stop + bring [player] to collision area 
        }else{go back to player}*/
    }
}


