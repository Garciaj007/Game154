using UnityEngine;

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
    private bool inWater = false;
    private bool aimUp = false;

    public float speed = 10.0f;
    public float jumpForce = 100.0f;
    public float aim;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        movement = Input.GetAxis("Horizontal") * speed;
        aim += Input.GetAxis("Mouse Y") / 10;

        Debug.Log(aim);

        if (Input.GetKeyUp(KeyCode.Space))
        {
            jump = true;
        } else
        {
            jump = false;
        }

        if(aim >= 1 && movement == 0)
        {
            aimUp = true;
        } else
        {
            aimUp = false;
        }

        if(movement < 0)
        {
            sp.flipX = true;
        } else
        {
            sp.flipX = false;
        }

        anim.SetBool("Moving", movement != 0 && !inWater);
        anim.SetBool("Jumping", jump && isGrounded);
        anim.SetBool("InWater", inWater);
        anim.SetBool("AimUp", aimUp);
        anim.SetFloat("Aim", aim);
	}

    void FixedUpdate()
    {
        rigid.velocity = new Vector2(movement, rigid.velocity.y);

        if (jump && isGrounded)
        {
            rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Water")
        {
            isGrounded = true;
        }

        if (collision.gameObject.tag == "Water")
        {
            inWater = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Water")
        {
            isGrounded = false;
        }

        if (collision.gameObject.tag == "Water")
        {
            inWater = false;
        }
    }
}
