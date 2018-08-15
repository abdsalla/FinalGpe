using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainterBlock : MonoBehaviour
{
    public Collider2D gCollider;
    public Collider2D rCollider;
    public Collider2D bCollider;

    // Use this for initialization
    void Start()
    {
        gCollider = GetComponent<Collider2D>();
        rCollider = GetComponent<Collider2D>();
        bCollider = GetComponent<Collider2D>();

        gCollider.isTrigger = true;
        bCollider.isTrigger = true;
        rCollider.isTrigger = true; 


    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //&& this.gameObject.tag == "GreenPainterBlock"
        // && this.gameObject.tag == "BluePainterBlock"
       // && this.gameObject.tag == "RedPainterBlock"
        //if (collision.gameObject.tag == this.gameObject.tag)
        
            if (collision.gameObject.tag == "GreenPaintBall" )
            {
                Debug.Log("got here");
                gCollider.isTrigger = false;

            }

            if (collision.gameObject.tag == "BluePaintBall")
            {
                bCollider.isTrigger = false;
                Debug.Log("got here");
            }

            if (collision.gameObject.tag == "RedPaintBall" )
            {
                rCollider.isTrigger = false;
                Debug.Log("got here");
            }
        
    }
}
