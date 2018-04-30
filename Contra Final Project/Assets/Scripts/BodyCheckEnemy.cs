using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCheckEnemy : MonoBehaviour
{
    public Transform left, right;
    public float speedX;

    private SpriteRenderer sp;

    protected void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    protected void Update()
    {
        Vector2 pos = transform.position;

        if (pos.x >= right.position.x)
        {
            speedX = -speedX;
        }

        if (pos.x <= left.position.x)
        {
            speedX = -speedX;
        }

        pos.x += speedX;

        transform.position = pos;

        if(speedX > 0)
        {
            sp.flipX = true;
        } else
        {
            sp.flipX = false;
        }
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().LoseLife();
            Debug.Log("Killed the player...");
        }
    }

    public void Explode()
    {
        //set the animation to explode to true...
        Debug.Log("Destroying this....");
        Destroy();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
