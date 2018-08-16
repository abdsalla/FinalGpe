using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazards : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameManager.instance.hazards.Add(this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            Destroy(collision.gameObject);
            GameManager.instance.score -= 100;
            GameManager.instance.lives -= 1;
            GameManager.instance.UpdateScore();
            GameManager.instance.playerState = GameManager.PlayerState.DEFAULT;
            GameManager.instance.playerIsAlive = false;
        }
    }

}
