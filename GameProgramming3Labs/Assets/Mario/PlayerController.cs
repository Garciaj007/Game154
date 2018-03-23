using UnityEngine;

public class PlayerController : MovementController {

    private float _x = 0;

    protected override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
        else
        {
            jump = false;
        }

        _x = Input.GetAxis("Horizontal") * speed;
    }

    protected override void FixedUpdate()
    {
        if (jump == true && isGrounded == true)
        {
            rigid.AddForce(Vector2.up * jumpForce);
        }

        rigid.velocity = new Vector2(_x, rigid.velocity.y);
    }
}
