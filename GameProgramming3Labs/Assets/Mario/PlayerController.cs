using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rigid;
    private float _x;
    [SerializeField]
    private bool isGrounded = false;
    [SerializeField]
    private bool jump = false;

    public float speed = 50.0f;
    public float jumpForce = 10000.0f;

	// Use this for initialization
	void Start () {
        rigid = this.gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () { 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        } else
        {
            jump = false;
        }

        _x = Input.GetAxis("Horizontal") * speed;
	}

    private void FixedUpdate()
    {
        if (jump == true && isGrounded == true)
        {
            rigid.AddForce(Vector2.up * jumpForce);
        }

        rigid.velocity = new Vector2(_x, rigid.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.tag == "Platform")
        {
            isGrounded = false;
        }
    }
}
