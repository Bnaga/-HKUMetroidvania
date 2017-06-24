using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject {

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    private bool shoot;
    bool faceLeft;
    float moverx;

    private Animator animator;


	// Use this for initialization
	void Awake ()
    {
        animator = GetComponent<Animator>();
	}

    // Update is called once per frame
    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");
        moverx = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
        }

        else if(Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
                velocity.y = velocity.y * 0.5f;
        }
        if(move.x < 0f)
        {
            faceLeft = true;
        }
        else if(move.x > 0f)
        {
            faceLeft = false;
        }

        animator.SetBool("FaceLeft", faceLeft);
        animator.SetFloat("MoveX", moverx);
        animator.SetBool("Grounded", grounded);
        animator.SetFloat("VeloX", Mathf.Abs(velocity.x) / maxSpeed);
        animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);
        animator.SetFloat("VeloY", Mathf.Abs(velocity.y) / jumpTakeOffSpeed);


        targetVelocity = move * maxSpeed;
    }


}
