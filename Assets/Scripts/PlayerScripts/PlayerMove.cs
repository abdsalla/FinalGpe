using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    // Use this for initialization
    public Animator animController;
    public float walkSpeed;
    public float jumpForce;
    public bool isGrounded;
    public int jumpsLeft;
    public JumpSound jumpsound;

    private Rigidbody2D thisRigidbody2D;
    private SpriteRenderer mySR;
    private RaycastHit2D hitInfo;
    private Vector3 raycastLocation;

    // Use this for initialization
    void Start()
    {
        mySR = GetComponent<SpriteRenderer>();
        animController = GetComponent<Animator>();
        thisRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /* State_Number == 1 aka walking
         * 2 == running
         * 0 == idle
         */


        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            mySR.flipX = true;
            animController.SetInteger("State_Number", 1);
            transform.position -= transform.right * Time.deltaTime * walkSpeed;

        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Time.deltaTime * walkSpeed;
            animController.SetInteger("State_Number", 1);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            mySR.flipX = false;
            animController.SetInteger("State_Number", 0);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            animController.SetInteger("State_Number", 0);
        }

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            walkSpeed = 3.5f;
            animController.SetInteger("State_Number", 2);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            walkSpeed = 2;
            animController.SetInteger("State_Number", 0);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        float castDist = 0.5f;
        hitInfo = Physics2D.Raycast(transform.position + Vector3.down * castDist, Vector2.up, castDist); // raycast starts below character then shoots up

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        //Debug.Log(hitInfo.collider.gameObject.tag);
        if (hitInfo.collider.tag == "Environment" || hitInfo.collider.tag == "BluePainterBlock" || hitInfo.collider.tag == "RedPainterBlock" || hitInfo.collider.tag == "GreenPainterBlock")
        {
            
            isGrounded = true;
        }
        else
        {
            
            isGrounded = false;
        }
    }


    // player has to be grounded to jump
    public void Jump()
    {
        if (isGrounded == true)
        {
            thisRigidbody2D.AddForce(transform.up * jumpForce, ForceMode2D.Force);
            jumpsound.PlayJump();
            isGrounded = false;
        }
    }
}