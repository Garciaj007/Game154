using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{

    private Animator anim;
    private Rigidbody2D rigid;

    public float speed = 50.0f;
    public float jumpForce = 1000.0f;
    public bool facingRight = true;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal") * speed, rigid.velocity.y);
        rigid.velocity = movement;

        if(movement.x > 0 && !facingRight)
        {
            Invert();
        } else if (movement.x < 0 && facingRight)
        {
            Invert();
        }
   
        anim.SetBool("Walking", movement.x != 0);
    }

    void Invert()
    {
        facingRight = !facingRight;
        this.GetComponent<SpriteRenderer>().flipX = !facingRight;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("Punch", true);
        } else if (Input.GetMouseButtonDown(1))
        {
            anim.SetBool("Kick", true);
        } else
        {
            anim.SetBool("Punch", false);
            anim.SetBool("Kick", false);
        }
    }
}
