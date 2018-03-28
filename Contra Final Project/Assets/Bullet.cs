using UnityEngine;

public abstract class Bullet : MonoBehaviour {

    protected GameObject parent;
    protected SpriteRenderer sp;
    protected Rigidbody2D rigid;
    protected Rigidbody2D p_rigid;
    protected float p_Aim;

    public float speed = 10.0f;

    // Use this for initialization
    protected void Start () {
        rigid = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();

        parent = GameObject.FindGameObjectWithTag("Player");

        if(parent != null)
        {
            p_Aim = parent.GetComponent<PlayerMovement>().aim;
            p_rigid = parent.GetComponent<Rigidbody2D>();

            rigid.velocity = new Vector2(speed, rigid.velocity.y);
        } else
        {
            Debug.LogWarning("Cannot Find Player .: Cannot move bullet");
            Destroy(gameObject);
        }
	}

    protected abstract void OnTriggerEnter2D(Collider2D collision);
}
