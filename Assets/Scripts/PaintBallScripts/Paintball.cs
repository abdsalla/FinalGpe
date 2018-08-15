using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paintball : MonoBehaviour {

    public float travelspeed; // speed of bullet defined by the designer
    public float lifespan; // how long the bullet stays airborne

    public Collider2D gCollider;
    public Collider2D rCollider;
    public Collider2D bCollider;


    GameObject player;

    // Use this for initialization
    void Start ()
    {
        player = GameManager.instance.player;
        transform.right = (transform.position - player.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.right * travelspeed; // every frame moves the bullet forward
        Destroy(gameObject, lifespan); // Destroy the bullet after the lifespan passes
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided");
        Debug.Log("hit this thing - " + collision.gameObject.tag);
        if (collision.gameObject.tag == "GreenPainterBlock")
        {
            GameManager.instance.score += 50;
            GameManager.instance.UpdateScore();
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;

            Debug.Log("Box Visible");
        }

        if (collision.gameObject.tag == "BluePainterBlock")
        {
            GameManager.instance.score += 50;
            GameManager.instance.UpdateScore();
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            Debug.Log("Box Visible");
        }

        if (collision.gameObject.tag == "RedPainterBlock")
        {
            GameManager.instance.score += 50;
            GameManager.instance.UpdateScore();
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;

            Debug.Log("Box Visible");
        }
    }
}