using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour {
    private GameObject Player;
    private GameObject PlayerDefault;

	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player");
        PlayerDefault = Player;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bluh")
        {
            SceneManager.LoadScene("scene1");
            //reset to defaults
        }
    }



    // Update is called once per frame
    void Update () {
		
	}
}
