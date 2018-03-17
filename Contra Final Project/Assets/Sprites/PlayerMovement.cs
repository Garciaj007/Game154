using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

[RequireComponent (typeof (SpriteRenderer))]
[RequireComponent (typeof (Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private Rigidbody2D rigid;
    [SerializeField]
    private SpriteRenderer sp;

    private float movement;
    private bool jump;
    private bool isGrounded = false;

    public float speed = 10.0f;
    public float jumpForce = 100.0f;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        movement = Input.GetAxis("Horizontal") * speed;
        //jump = Convert.ToBoolean(Input.GetAxis("Jump"));
	}

    void FixedUpdate()
    {
        rigid.velocity = new Vector2(movement, rigid.velocity.y);
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
