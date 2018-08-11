using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GrapplingHookMovementCtrler : MonoBehaviour {

    public Rigidbody2D GrappleBody;
    public GameObject Grapplehook;
    public GameObject Player;
    private Transform Origin;
    private float DeltaMove;
    private float PositionDifference;
    public float GrappleForceX = 1000f;
    public float GrappleForceY = 900f;
    public float GHslow = 5f;
    public float RopeDistance = 5f;
    private float AcceptableDist = .3f;
    private bool thrown;
    private bool returning;
    private float pullBackSpeed = 3f;
    private bool ActivePull = false;


    private void Start()
    {
        Grapplehook = GameObject.Find("Grapplehook");
        GrappleBody = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");

    }

    private void Direction()
    {
        if (Input.GetButton("MoveRight") == true || Input.GetButton("right") == true)
        {
            GrappleForceX = 1000f;
        }
        if (Input.GetButton("MoveLeft") == true || Input.GetButton("left") == true)
        {
            GrappleForceX = -1000f;
        }

    }
    private void FindPosition() {
        Vector3 Grap = Grapplehook.transform.position;
        Vector3 plyr = Player.transform.position;
        PositionDifference = Vector3.Distance(Grap, plyr);
    }
    private void BackToPlayer()
    {
        if (PositionDifference >= RopeDistance)
        {

            if (PositionDifference >= RopeDistance + 2f)
            { //this code will run if PositionDifference is bigger than RopeDistance by an excessive amount. Should be faster than diffault
                pullBackSpeed = 8f;
            }
            else
            { //this code will run if PositionDifference is bigger than RopeDistance but not by an excessive amount. should be faster than diffault
                pullBackSpeed = 5f;
            }
        }
        else
        { //this will run if PositionDifference is NOT greater than RopeDistance. It should be set to what you had as the diffault before.
            pullBackSpeed = 3f;
        }
        if (ActivePull == true) {
            pullBackSpeed = 16f;
        }

        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, pullBackSpeed * Time.deltaTime);

        if (false)//wanted all this to be collapsable.
        {
            //float GrapX = Grapplehook.transform.position.x;
            //float GrapY = Grapplehook.transform.position.y;
            //float PlyrX = Player.transform.position.x;
            //float PlyrY = Player.transform.position.y;
            //if (GrapX < PlyrX) //if plyrX < grapX then grapplehook is to the right of player
            //{
            //    if (GrapY < PlyrY)
            //    {
            //        //in this block Grapplehook is to the Left and below Player
            //        GrappleBody.AddForce(new Vector3(GrappleForceX, GrappleForceY, 0f));
            //    }
            //    if (GrapY > PlyrY)
            //    {
            //        //in this block Grapplehook is to the Left and above Player
            //        GrappleBody.AddForce(new Vector3(GrappleForceX, -GrappleForceY, 0f));
            //    }
            //}
            //if (GrapX > PlyrX)
            //{
            //    if (GrapY < PlyrY)
            //    {
            //        //in this block Grapplehook is to the Right and below Player
            //        GrappleBody.AddForce(new Vector3(-GrappleForceX, GrappleForceY, 0f));
            //    }
            //    if (GrapY > PlyrY)
            //    {
            //        //in this block Grapplehook is to the Right and above Player
            //        GrappleBody.AddForce(new Vector3(-GrappleForceX, -GrappleForceY, 0f));
            //    }
            //}
        }
    }
    private void CheckThrown()
    {
        if (thrown == true && PositionDifference <= AcceptableDist /*&& GrappleBody.velocity.x <= m && GrappleBody.velocity.y <= m*/)
        {
        thrown = false;
            ActivePull = false;
        }
    }
 
    private void FixedUpdate()
    {
        FindPosition();
        Direction();
        Origin = Player.transform;
   //     Debug.Log("" + GrappleBody.velocity);
        if (Input.GetButtonDown("Grapple") && PositionDifference < RopeDistance) //"throws" the grapplehook. only one direction currently.
        {
            
            //Debug.Log(GrappleForceX);
            GrappleBody.AddForce(new Vector2(GrappleForceX, GrappleForceY));
            GrappleBody.drag = GHslow;
            thrown = true;
            returning = false;

        }
        if  (PositionDifference >= RopeDistance || Grapplehook.transform.position != Player.transform.position)
        {
            BackToPlayer();
            
            //add code to check if grapplehook is with player. this might be a bit weird until that
            //GrappleBody.AddForce(new Vector3(-GrappleForceX, -GrappleForceY, 0f));
            //(code)find fastest course to player and add force in that direction
            //  GrappleBody.MovePosition(Player.transform.position);
            //Move Grapplehook to Player X & Y
        }
        if (thrown == false)
        {
            Grapplehook.transform.position = Player.transform.position; }



    }
    // Update is called once per frame
    void Update() {
        if (PositionDifference >= AcceptableDist) {
            returning = true;
        }
        if ( returning == true ) { 
        CheckThrown();
            if (Input.GetButtonDown("down") == true)
            {
                ActivePull = true;
            }
        }


        /*what I need to do, in psudo-code:
         when(buttonpressed) {
         grapplehook goes to place. 
        }
        if(runs into interactable thing){
       Stop + bring [player] to collision area 
        }else{go back to player}*/
    }
}

     
