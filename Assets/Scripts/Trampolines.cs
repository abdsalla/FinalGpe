using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolines : MonoBehaviour {

    public PlayerMove pM;  // player reference

	// Use this for initialization
	void Start () {
        pM = GetComponent<PlayerMove>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /* Increase jumpheight when on red boxes
     * 
     * Goes back to normal when leaving the trigger
     */ 


    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pM = collision.gameObject.GetComponent<PlayerMove>();
            pM.jumpForce = 500;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pM.jumpForce = 350;
        }
    }
}
