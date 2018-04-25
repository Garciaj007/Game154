using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour {

    private Vector2 h_Throw;
    private Animator anim;
    private Rigidbody2D rigid;

    public float speed;

    private void Awake()
    {
        h_Throw = Vector2.zero;
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	private void Update () {
        if(transform.position.y < -200)
        {
            Destroy(gameObject);
        }
    }

    public void ThrowHammer()
    {
        float x = Random.Range(-1.0f, 0.0f);
        float y = Random.Range(0.0f, 1.0f);

        h_Throw.Set(x, y);
        h_Throw *= speed;

        rigid.isKinematic = false;
        rigid.AddForce(h_Throw, ForceMode2D.Impulse);

        anim.SetBool("Thrown", true);
    }
}
