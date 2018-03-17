using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rigid;
    private Vector2 position;

	// Use this for initialization
	void Start () {
        rigid = this.gameObject.GetComponent<Rigidbody2D>();
        position.x = transform.position.x;
        position.y = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {

        float horizontalMovement = Input.GetAxis("Horizontal");
        rigid.AddForce(new Vector2(horizontalMovement * 10, 0.0f), ForceMode2D.Impulse);

        if (Input.GetButtonUp("Jump"))
        {
            rigid.AddForce(Vector2.up * 10000);
        }
	}
}
