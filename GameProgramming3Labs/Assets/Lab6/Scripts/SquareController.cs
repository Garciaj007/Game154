using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareController : MovementController {

    private float _x = 0.0f;

	// Update is called once per frame
	protected override void Update () {
        _x = Input.GetAxis("Horizontal") * speed;

        if (Input.GetKey(KeyCode.Space))
        {
            jump = true;
        }
        else
        {
            jump = false;
        }
    }

    protected override void FixedUpdate()
    {
        if (jump == true && isGrounded == true)
        {
            rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        rigid.velocity = new Vector2(_x, rigid.velocity.y);
    }
}
