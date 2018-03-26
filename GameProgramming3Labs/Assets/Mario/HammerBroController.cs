using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class HammerBroController : MovementController
{

    private int activeState = 0;
    private Rigidbody2D h_Rigid;
    private Vector2 v2h_velocity = Vector2.zero;
    private IEnumerator IE_move;
    
    private float totalTime;

    public Dictionary<int, string> enemyStates = new Dictionary<int, string>();
    public GameObject hammer;
    public Transform hand;
    public float throwSpeed = 2.0f;
    public float duration = 2.0f;

    public enum State
    {
        Wander,
        MoveForward,
        MoveBack,
        Hammer,
        Throw,
        Jump,
        Die
    }

    //Yield return null returns to the next coroutine
    //yield return new Waitforseconds(time) returns a new time pause for certain amount of seconds
    //yeild return StartCoroutine() waits for when the coroutine has finished

    private void Start()
    {
        base.Start();

        enemyStates.Add(0, "Wander");
        enemyStates.Add(1, "MoveForward");
        enemyStates.Add(2, "MoveBack");
        enemyStates.Add(3, "Hammer");
        enemyStates.Add(4, "Throw");
        enemyStates.Add(5, "Jump");
        enemyStates.Add(6, "Die");

        totalTime = Time.time + duration;
    }

    protected override void Update()
    {
        Wander();


        if(rigid.velocity.x > 0)
        {
            sp.flipX = true;
        } else
        {
            sp.flipX = false;
        }
    }

    protected override void FixedUpdate()
    {
        if (jump && isGrounded)
        {
            rigid.AddForce(Vector2.up * jumpForce);
            jump = false;
        }

        rigid.velocity = v2h_velocity;
    }

    private void Wander()
    {
        if(Time.time > totalTime)
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
            } else
            {
                Idle();
            }
            totalTime = Time.time + duration;
        }
    }

    private void Idle()
    {
        if(IE_move != null)
        {
            StopCoroutine(IE_move);
        }

        v2h_velocity.Set(0, rigid.velocity.y);
    }

    private void MoveForward()
    {
        if(IE_move != null)
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
       if(rigid != null)
        {
            v2h_velocity = new Vector2(x, rigid.velocity.y);
            yield return null;
        }
    }

    protected void Hammer()
    {
        //if no hammer in hand, create one
        h_Rigid = hammer.GetComponent<Rigidbody2D>();
        Instantiate(hammer, hand);
    }

    protected void Throw()
    {
        float x = Random.Range(-1, 0);
        float y = Random.Range(0, 1);

        Vector2 h_Throw = new Vector2(x, y);
        h_Throw *= throwSpeed;
        h_Rigid.AddForce(h_Throw);
    }

    protected void Jump()
    {
        //set boolean jump to true
        jump = true;
    }

    protected void Die()
    {
        //kill this enemy
        Destroy(gameObject);
    }

    public void SetActiveState(int state)
    {
        activeState = state;
    }

}