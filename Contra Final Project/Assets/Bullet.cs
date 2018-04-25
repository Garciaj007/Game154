using UnityEngine;

public class Bullet : MonoBehaviour {

    protected GameObject parent;
    protected SpriteRenderer sp;

    public Vector2 speed = new Vector2(0.0f, 0.0f);


    // Use this for initialization
    protected void Start () {
      
	}

    protected void Update()
    {
        Vector2 pos = transform.position;
        pos.x += speed.x;
        pos.y += speed.y;
        transform.position = pos;
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().OnDestroy();
        }
    }
}
