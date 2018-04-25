using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerBro : MonoBehaviour
{

    public Hammer hammer, h;
    public Detector playerEnterDetector;
    public Detector playerInRangeDetector;
    public Detector tooCloseDetector;
    public Transform hand;
    public GameObject player;
    public float fireRate, speed, duration;

    private float currentTime, totalTime;
    private bool h_InHand = false, chase = false, stepBack = false;
    private Vector2 velocity = Vector2.zero;
    private Animator anim;
    private Rigidbody2D rigid;
    private SpriteRenderer sp;
    //private IEnumerator IE_move;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Use this for initialization
    void Start()
    {
        playerEnterDetector.OnStayListener = Chase;
        playerEnterDetector.OnExitListener = Idle;

        playerInRangeDetector.OnStayListener = PlayerEnterDetector;//start to move and throw hammers
        playerInRangeDetector.OnExitListener = PlayerExitDetector; //delete hammers

        tooCloseDetector.OnStayListener = StepBack;
        tooCloseDetector.OnExitListener = PlayerEnterDetector;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;

        if (rigid.velocity.x > 0)
        {
            sp.flipX = true;
        }
        else
        {
            sp.flipX = false;
        }

        if (chase)
        {
            rigid.AddForce(new Vector2(-50.0f, 0.0f));
        } else if (stepBack)
        {
            if (Random.Range(0, 6) == 5)
            {
                rigid.AddForce(new Vector2(50, 0.0f));
            }
        } else
        {
            rigid.velocity = new Vector3(0, rigid.velocity.y, 0);
        }

        anim.SetBool("Hammer", h_InHand);
    }

    void PlayerEnterDetector()
    {
        chase = false;
        stepBack = false;

        if (currentTime <= 0 && h_InHand == false)
        {
            currentTime = Random.Range(1.0f, 3.0f);
            CreateHammer(h, hand.position);
            h_InHand = true;
        }

        if (currentTime <= 0 && h_InHand == true)
        {
            currentTime = fireRate;
            hammer.ThrowHammer();
            h_InHand = false;
        }

        int rdm = Random.Range(0, 50);
        Debug.Log(rdm);
        if (rdm == 21)
        {
            Jump();
        }
        else if (rdm == 31)
        {
            JumpDown();
        }
    }

    void PlayerExitDetector()
    {
        if (hammer != null)
        {
            Destroy(hammer);
        }
    }

    void CreateHammer(Hammer hammerObject, Vector3 position)
    {
        hammer = GameObject.Instantiate<Hammer>(hammerObject, position, Quaternion.identity);
    }

    void Jump()
    {
        Debug.Log("Jump");
        rigid.AddForce(Vector2.up * 5000.0f);
    }

    void JumpDown()
    {
        Debug.Log("Jumpdown");
    }

    void Chase()
    {
        chase = true;
    }

    void Idle()
    {
        Debug.Log("Idle");
        chase = false;
    }

    void StepBack()
    {
        stepBack = true;
        Debug.Log("StepBack");
    }

    //void Wander()
    //{
    //    if (Time.time > totalTime)
    //    {
    //        int choice = Random.Range(0, 5);
    //        Debug.Log(choice);
    //        if (choice == 0)
    //        {
    //            MoveForward();
    //        }
    //        else if (choice == 1)
    //        {
    //            MoveBack();
    //        }
    //        else
    //        {
    //            Idle();
    //        }
    //        totalTime = Time.time + duration;
    //    }
    //}

    //void Jump()
    //{
    //    rigid.AddForce();
    //}

    //private void MoveForward()
    //{
    //    if (IE_move != null)
    //    {
    //        StopCoroutine(IE_move);
    //    }
    //    IE_move = Move(-speed);
    //    StartCoroutine(IE_move);
    //}

    //private void MoveBack()
    //{
    //    if (IE_move != null)
    //    {
    //        StopCoroutine(IE_move);
    //    }
    //    IE_move = Move(speed);
    //    StartCoroutine(IE_move);
    //}

    //private IEnumerator Move(float x)
    //{
    //    if (rigid != null)
    //    {
    //        rigid.MovePosition();
    //        yield return null;
    //    }
    //}

}
