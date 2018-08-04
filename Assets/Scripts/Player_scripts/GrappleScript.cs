using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleScript : MonoBehaviour {
    public GameObject Player;
    public GameObject Grapplehook;
    public Rigidbody2D PlayerBody;
    public Rigidbody2D GrappleBody;
    private Vector2 PlXY;
    public float Spd = 3f;

    // Use this for initialization
    void Start () {
        Player = GameObject.Find("Player");
        Grapplehook = GameObject.Find("Grapplehook");
        GrappleBody = Grapplehook.GetComponent<Rigidbody2D>();
        PlayerBody = Player.GetComponent<Rigidbody2D>();
    }

    private IEnumerator Moveplyr(Vector3 grapplePostion) {
        float dist = Vector3.Distance(grapplePostion, Player.transform.position);
        while (dist >= 1.105f) {
            PlayerBody.MovePosition(Vector2.MoveTowards(Player.transform.position, grapplePostion, Spd * Time.deltaTime));
            yield return null;
            dist = Vector3.Distance(grapplePostion, Player.transform.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if ( collision.tag == "grappleTag")
        {
            StartCoroutine(Moveplyr(collision.transform.position));
            GrappleBody.velocity = new Vector3(0, 0, 0);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
