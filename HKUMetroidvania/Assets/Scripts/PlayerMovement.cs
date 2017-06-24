using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    float walkSpeed = 10;
    float runSpeed = 5;
    public int jumpCount = 2;
    private Rigidbody2D playerBody;
    private bool playerMoving;
    public float jumpSpeed = 20.0f;

    // Use this for initialization
    void Start ()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        float move = Input.GetAxis("Horizontal");

        playerBody.velocity = new Vector2(move * walkSpeed, playerBody.velocity.y);

        if(jumpCount >= 1 && Input.GetButtonDown("Jump"))
        {
            playerBody.velocity = new Vector2(move * walkSpeed, jumpSpeed);
            jumpCount -= 1;
        }
    }
}
