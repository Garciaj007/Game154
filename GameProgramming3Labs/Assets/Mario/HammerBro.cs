using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerBro : MonoBehaviour {

    public Hammer hammer, h;
    public Detector detector;
    public Transform hand;
    public float fireRate, speed, duration;

    private float currentTime, totalTime;
    private bool h_InHand = false;
    private Vector2 velocity = Vector2.zero;
    private Animator anim;
    private Rigidbody2D rigid;
    private SpriteRenderer sp;
    private IEnumerator IE_move;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Use this for initialization
    void Start () {
        detector.OnStayListener = OnStayDetected;//start to move and throw hammers
        detector.OnExitListener = OnExitDetected;//remain Idle
	}
	
	// Update is called once per frame
	void Update () {
        currentTime -= Time.deltaTime;

        //if(idle) then remain idle

        //if(!idle) move around and jump

        if (rigid.velocity.x > 0)
        {
            sp.flipX = true;
        }
        else
        {
            sp.flipX = false;
        }

        anim.SetBool("Hammer", h_InHand);
	}

    void OnStayDetected()
    {
        if(currentTime <= 0 && h_InHand == false)
        {
            currentTime = Random.Range(1.0f, 3.0f);
            CreateHammer(h, hand.position);
            h_InHand = true;
        }

        if(currentTime <= 0 && h_InHand == true)
        {
            currentTime = fireRate;
            hammer.ThrowHammer();
            h_InHand = false;
        }
    }

    void OnExitDetected()
    {
        if(hammer != null)
        {
            Destroy(hammer);
        }
    }

    void CreateHammer(Hammer hammerObject, Vector3 position)
    {
        hammer = GameObject.Instantiate<Hammer>(hammerObject, position, Quaternion.identity);
    }

    void Wander()
    {
        if (Time.time > totalTime)
        {
            int choice = Random.Range(0, 5);
            Debug.Log(choice);
            if (choice == 0)
            {
                MoveForward();
            }
            else if (choice == 1)
            {
                MoveBack();
            }
            else
            {
                Idle();
            }
            totalTime = Time.time + duration;
        }
    }

    void Jump()
    {

    }

    private void Idle()
    {
        if (IE_move != null)
        {
            StopCoroutine(IE_move);
        }

        velocity.Set(0, rigid.velocity.y);
    }

    private void MoveForward()
    {
        if (IE_move != null)
        {
            StopCoroutine(IE_move);
        }
        IE_move = Move(-speed);
        StartCoroutine(IE_move);
    }

    private void MoveBack()
    {
        if (IE_move != null)
        {
            StopCoroutine(IE_move);
        }
        IE_move = Move(speed);
        StartCoroutine(IE_move);
    }

    private IEnumerator Move(float x)
    {
        if (rigid != null)
        {
            velocity = new Vector2(x, rigid.velocity.y);
            yield return null;
        }
    }

}
