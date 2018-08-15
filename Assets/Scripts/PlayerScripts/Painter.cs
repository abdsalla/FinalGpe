using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painter : MonoBehaviour {

    public float spawnDistance;
    public List<Rigidbody2D> paintBalls;
    public PaintSound paintSound;

    // Use this for initialization
    void Start () {
        
	}

     
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0) && GameManager.instance.playerState == GameManager.PlayerState.PAINT)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Vector3 target = Vector3.Normalize(transform.position - mousePosition);
            Vector3 target = Vector3.Normalize(mousePosition - transform.position);
            target.z = 0;
            int randint = Random.Range(0, 3);
            Instantiate(paintBalls[randint], (transform.position + (target * spawnDistance)), GetComponent<Transform>().rotation);
            paintSound.PlayPaint();
            
        }
    }
}
