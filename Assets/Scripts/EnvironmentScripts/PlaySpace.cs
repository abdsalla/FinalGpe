using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySpace : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        if (collision.gameObject.tag == "Player")
        {
            
            GameManager.instance.score -= 100;
            GameManager.instance.UpdateScore();
            GameManager.instance.playerState = GameManager.PlayerState.DEFAULT;
            GameManager.instance.playerIsAlive = false;
        }
    }
}
