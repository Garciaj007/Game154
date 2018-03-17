using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class CharacterMovement : MonoBehaviour
{
    public Text someText;
    public Transform downStairs;
    public Transform upStairs;

    private Vector2 movement;
    private Animator anim;
    private Animator d_anim;
    private new Transform transform;
    private Rigidbody2D rigid;
    private Rigidbody2D b_rigid;
    private bool onTeleport = false;
    private bool disabled = false;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        transform = GetComponent<Transform>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");

            if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                movement.x = 0;
            }
            else if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
            {
                movement.y = 0;
            }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            rigid.isKinematic = !rigid.isKinematic;
        }

        anim.SetBool("IsFishing", Input.GetAxis("Fire2") != 0);
        anim.SetBool("IsMoving", movement != Vector2.zero && disabled != true);
        anim.SetFloat("X", movement.x);
        anim.SetFloat("Y", movement.y);
    }

    void FixedUpdate()
    {
        if(disabled != true)
        {
            transform.position += new Vector3(movement.x, movement.y, 0.0f);
        }
    }

    void RemoveForce()
    {
        b_rigid.velocity = Vector2.zero;
        d_anim.Play("Dust");
        disabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Boulder")
        {
            d_anim = collision.gameObject.transform.GetChild(0).GetComponent<Animator>();
            b_rigid = collision.gameObject.GetComponent<Rigidbody2D>();
            disabled = true;
            if(Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
            {
                if(Mathf.Sign(movement.x) > 0)
                {
                    b_rigid.transform.rotation = Quaternion.Euler(0, 0, -Mathf.Sign(movement.x) * 180);
                } else
                {
                    b_rigid.transform.rotation = Quaternion.Euler(0, 0, -Mathf.Sign(movement.x));
                }
                
                b_rigid.AddForce(new Vector2(Mathf.Sign(movement.x) * 50, 0), ForceMode2D.Impulse);
            } else
            {
                b_rigid.transform.rotation = Quaternion.Euler(0, 0, -Mathf.Sign(movement.y) * 90);
                b_rigid.AddForce(new Vector2(0, Mathf.Sign(movement.y) * 50), ForceMode2D.Impulse);
            }
            Invoke("RemoveForce", 1);   
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Trigger")
        {
            someText.enabled = true;
        }

        if (collision.gameObject.name == "Downstairs")
        {
            if (onTeleport == false)
            {
                onTeleport = true;
                this.transform.position = upStairs.position;
            }
            else
            {
                onTeleport = false;
            }
        }

        if (collision.gameObject.name == "Upstairs")
        {
            if (onTeleport == false)
            {
                onTeleport = true;
                this.transform.position = downStairs.position;
            }
            else
            {
                onTeleport = false;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Trigger")
        {
            someText.enabled = false;
        }
    }
}
