using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // spawning player at specific checkpoints if they reach it and die

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.checkPoint.Set(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0);
        }
    }
}
