using UnityEngine;

public abstract class MovementController : MonoBehaviour {

    public float speed = 50.0f;
    public float jumpForce = 1000.0f;

    protected Rigidbody2D rigid;
    protected Animator anim;
    protected SpriteRenderer sp;
    protected bool isGrounded = false;
    protected bool jump = false;
    protected bool facingRight = true;

    //Implemented Methods
	protected void Start () {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
	}

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isGrounded = true;
        }
    }

    protected void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isGrounded = false;
        }
    }

    protected void Invert()
    {
        facingRight = !facingRight;
        sp.flipX = !facingRight;
    }

    //Abstract Methods
    protected abstract void Update();
    protected abstract void FixedUpdate();
    //protected abstract void OnTriggerEnter2D(Collider2D other);
    //protected abstract void OnTriggerExit2D(Collider2D other);
}
