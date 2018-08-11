using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class getTheRuby : MonoBehaviour {
    private GameObject Ruby;
    public ParticleSystem sparkles;


    // Use this for initialization
    void Start () {
        Ruby = GameObject.Find("Ruby");

    }
    IEnumerator Example()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("scene1");

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            sparkles.Play();
            Ruby.transform.position += new Vector3(0,0,-15);
            StartCoroutine(Example());
        }

    }
            // Update is called once per frame
            void Update () {
		
	}
}
