using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigid;
    private SpriteRenderer sp;
    private Animator anim;

    private float movement;
    private float aim;

    private bool jump;
    private bool isGrounded = false;
    private bool inWater = false;
    private bool aimUp = false;

    public float speed = 10.0f;
    public float jumpForce = 100.0f;

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        aim = Input.GetAxis("Vertical");
        jump = Input.GetKeyDown(KeyCode.Space);

        rigid.velocity = new Vector2(movement * speed, rigid.velocity.y);

        if (jump && isGrounded)
        {
            rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
        }

        if (aim >= 1 && movement == 0)
        {
            aimUp = true;
        }
        else
        {
            aimUp = false;
        }

        if (movement < 0)
        {
            sp.flipX = true;
        }
        else
        {
            sp.flipX = false;
        }

        anim.SetBool("Moving", movement != 0 && !inWater);
        anim.SetBool("Jumping", jump && isGrounded);
        anim.SetBool("InWater", inWater);
        anim.SetBool("AimUp", aimUp);
        anim.SetFloat("Aim", aim);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = GetComponent<Collider2D>();

        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Water" || collision.gameObject.tag == "Ground")
        {
            Vector3 contactPoint = collision.contacts[0].point;
            Vector3 center = collider.bounds.center;

            if (contactPoint.y < center.y)
            {
                isGrounded = true;
            }
        }

        if (collision.gameObject.tag == "Water")
        {
            Vector3 contactPoint = collision.contacts[0].point;
            Vector3 center = collider.bounds.center;

            if (contactPoint.y < center.y)
            {
                inWater = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Water" || collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }

        if (collision.gameObject.tag == "Water")
        {
            inWater = false;
        }
    }

    public bool AimUp()
    {
        return aimUp;
    }

    public bool Flipped()
    {
        return sp.flipX;
    }

    public float Aim()
    {
        return aim;
    }

    public float Movement()
    {
        return Movement();
    }

    public Vector2 AimDirection()
    {
        Vector2 direction = new Vector3(0.0f, 0.0f, 0.0f);

        if (aimUp)
        {
            direction = new Vector2(0.0f, 1.0f);
        }

        if (aim == 0)
        {
            direction = new Vector2(1.0f, 0.0f);
        }

        if (movement == 1 && aim == 1)
        {
            direction = new Vector2(1, 1);
        }

        if (movement == 1 && aim == -1)
        {
            direction = new Vector2(1, -1);
        }

        if (movement == -1 && aim == 0)
        {
            direction = new Vector2(-1.0f, 0.0f);
        }

        if (movement == -1 && aim == 1)
        {
            direction = new Vector2(-1, 1);
        }

        if (movement == -1 && aim == -1)
        {
            direction = new Vector2(-1, -1);
        }

            return direction;
    }


}
