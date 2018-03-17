using UnityEngine;
using System;

[RequireComponent (typeof (SpriteRenderer))]
[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Animator))]
public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rigid;
    private SpriteRenderer sp;
    private Animator anim;

    private float movement;
    private bool jump;
    private bool isGrounded = false;

    public float speed = 10.0f;
    public float jumpForce = 100.0f;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        movement = Input.GetAxis("Horizontal") * speed;
        jump = Convert.ToBoolean(Input.GetAxis("Jump"));

        if(movement < 0)
        {
            sp.flipX = true;
        } else
        {
            sp.flipX = false;
        }

        anim.SetBool("Moving", movement != 0);
        anim.SetBool("Jumping", jump && isGrounded);
        Debug.Log(movement);
	}

    void FixedUpdate()
    {
        rigid.velocity = new Vector2(movement, rigid.velocity.y);

        if (jump && isGrounded)
        {
            rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        } 

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            isGrounded = false;
        }
    }
}
