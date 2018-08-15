using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GrapplingHookMovementCtrler : MonoBehaviour {

    public Rigidbody2D GrappleBody;
    public GameObject Grapplehook;
    public GameObject Player;
    private Rigidbody2D PlayerBody;
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
        PlayerBody = Player.GetComponent<Rigidbody2D>();

    }

    private void Direction()
    {
        //receves input to tell the grappling hook where to go. Will probably be replaced with a better system in the future.
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
             //this code will run if PositionDifference is bigger than RopeDistance
                pullBackSpeed = 7f;
        }
        else
        { //this will run if PositionDifference is NOT greater than RopeDistance. It should be set to what you had as the diffault before.
            pullBackSpeed = 5f;
        }
        if (ActivePull == true) {
            pullBackSpeed = 16f;
        }
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, pullBackSpeed * Time.deltaTime);
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
        if (Input.GetButtonDown("Grapple") && PositionDifference < AcceptableDist)
        {
         //"throws" the grapplehook. 

            //Debug.Log(GrappleForceX);
            GrappleBody.AddForce(new Vector2(GrappleForceX, GrappleForceY));
            GrappleBody.drag = GHslow;
            thrown = true;
            returning = false;

        }
        if  (PositionDifference >= RopeDistance || PositionDifference >= AcceptableDist)
        {
            BackToPlayer();
            
            //add code to check if grapplehook is with player. this might be a bit weird until that
            //GrappleBody.AddForce(new Vector3(-GrappleForceX, -GrappleForceY, 0f));
            //(code)find fastest course to player and add force in that direction
            //  GrappleBody.MovePosition(Player.transform.position);
            //Move Grapplehook to Player X & Y
        }
        
    }

    // Update is called once per frame
    void Update() {
        if (thrown == false)
        {
            Grapplehook.transform.position = Player.transform.position;
        }
        if (PositionDifference >= AcceptableDist) {
            returning = true;
        }
        if (returning == true) {
            CheckThrown();
            if (Input.GetButtonDown("down") == true)
            {
                ActivePull = true;
            }
        }
        if (thrown == true)
        {
            float Speed = .1f;
            float RunSpeed = .02f;
            if (Input.GetButton("MoveRight") == true)
            {
                transform.position += new Vector3(Speed, 0f, 0f);
            }
            if (Input.GetButton("MoveLeft") == true)
            {
                transform.position += new Vector3(-Speed, 0f, 0f);
            }
            if (Input.GetButton("Run") == true && Speed <= .15f)
            {
                Speed = Speed + RunSpeed;
            }
            else
            {
                if (Speed > .1f)
                {
                    Speed = Mathf.Max(Speed - .01f * Time.deltaTime, .1f);
                }

            }

        }
    }

}
