using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementController : MonoBehaviour {
    public GameObject Camera1;
    public GameObject Player;
    private float PosDif;
    private float PosDifDefault;
    private Vector3 PlyrOrigin;
    private float PlyrX;
    private float PlyrY;
    private float CamX;
    private float CamY;
    private float DistanceDefaultX;
    private float DistanceDefaultY;




    // Use this for initialization
    void Start () {
        Camera1 = GameObject.Find("Main Camera");
        Player = GameObject.Find("Player");
        PosDifDefault = Vector3.Distance(Camera1.transform.position, Player.transform.position);
        SetDefaults();
    }
    private void CleverName()
    {
        PlyrX = Player.transform.position.x;
        PlyrY = Player.transform.position.y;
        CamX = Camera1.transform.position.x;
        CamY = Camera1.transform.position.y;
        float ThisY = PlyrY + DistanceDefaultY;
        float ThisX = PlyrX + DistanceDefaultX;
        Camera1.transform.position = new Vector3( ThisX, ThisY, -10f);

        //   Camera1.transform.position.y = PlyrY + DistanceDefaultY;

    }

    private void SetDefaults()
    {
        PlyrX = Player.transform.position.x;
        PlyrY = Player.transform.position.y;
        CamX = Camera1.transform.position.x;
        CamY = Camera1.transform.position.y;

        DistanceDefaultX = CamX - PlyrX;
        DistanceDefaultY = CamY - PlyrY;
    }

    private void GetDistance() {
        Vector3 Cam = Camera1.transform.position;
        Vector3 Plyr = Player.transform.position;
        PosDif = Vector3.Distance(Cam, Plyr);
    }
    // Update is called once per frame
    void Update () {
        GetDistance();
        if (PosDif != PosDifDefault)
        {
            CleverName();
        }
        if (PosDif == PosDifDefault)
        {
            PlyrOrigin = Player.transform.position;
        }

    }
}
