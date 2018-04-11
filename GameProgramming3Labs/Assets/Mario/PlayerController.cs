using UnityEngine;

public class PlayerController : MovementController {

    private float _x = 0;

    protected override void Update()
    {
        _x = Input.GetAxis("Horizontal") * speed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
        else
        {
            jump = false;
        }

        if (_x > 0 && !facingRight)
        {
            Invert();
        }
        else if (_x < 0 && facingRight)
        {
            Invert();
        }

        anim.SetBool("Jump", jump);
        anim.SetBool("Walking", _x != 0);
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
