using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public Rigidbody2D paintShot;
    private Animator animator;
    bool attack;
    int attackTimer;
    public PlayerController player;
    private float bulletSpeed = 400.0f;
    private float xShot = 1.5f;
    private float bulletHealth = 1.0f;
    public SpriteRenderer paintSprite;
    // Use this for initialization
    void Awake ()
    {
        animator = GetComponent<Animator>();
	}

    private void Start()
    {
        player = new PlayerController(); 
    }

    // Update is called once per frame
    void Update ()
    {
		if(Input.GetButtonDown("Fire1"))
        {
            attack = true;

        }

        if(attack)
        {
            attackTimer++;
            if(attackTimer > 5)
            {
                Fire();
                attack = false;
                attackTimer = 0;
            }

        }
        animator.SetBool("Attack", attack);
        

    }

    void Fire()
    {
        if (!animator.GetBool("FaceLeft"))
        {
            paintSprite.flipX = false;
            Rigidbody2D paint = Instantiate(paintShot, new Vector3(transform.position.x + xShot, transform.position.y, transform.position.z), Quaternion.identity) as Rigidbody2D;
            paint.AddForce(transform.right * bulletSpeed);
            //shotsrc.PlayOneShot(shotClip, 1.0f);
            Destroy(paint.gameObject, bulletHealth);
        }

        else if (animator.GetBool("FaceLeft"))
        {
            paintSprite.flipX = true;
            Rigidbody2D paint  = Instantiate(paintShot, new Vector3(transform.position.x - xShot, transform.position.y, transform.position.z), Quaternion.identity) as Rigidbody2D;
            paint.AddForce(transform.right * -bulletSpeed);
            //shotsrc.PlayOneShot(shotClip, 1.0f);
            Destroy(paint.gameObject, bulletHealth);
        }
    }
}
