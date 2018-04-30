using UnityEngine;

public class Bullet : MonoBehaviour {

    protected GameObject parent;
    protected SpriteRenderer sp;

    public Vector2 speed;
    public string b_Name = " ";

    protected void Start()
    {
        Invoke("Destroy", 1.5f);
    }

    protected void Update()
    {
        Vector2 pos = transform.position;
        pos.x += speed.x;
        pos.y += speed.y;
        transform.position = pos;

        if(speed.x == 0 && speed.y == 0)
        {
            Destroy();
        }
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(b_Name);
        if (collision.gameObject.tag == "Enemy" && b_Name == "PlayerBullet")
        {
            if (collision.gameObject.GetComponent<Enemy>() != null)
            {
                Debug.Log("powerbay set to explode....");
                collision.gameObject.GetComponent<Enemy>().Explode();
            }
            else if (collision.gameObject.GetComponent<BodyCheckEnemy>() != null)
            {
                Debug.Log("Capsule set to explode....");
                collision.gameObject.GetComponent<BodyCheckEnemy>().Explode();
            }
        }

        if (collision.gameObject.tag == "Entities" && b_Name == "PlayerBullet")
        {
            if (collision.gameObject.GetComponent<PowerUpBay>() != null)
            {
                Debug.Log("powerbay set to explode....");
                collision.gameObject.GetComponent<PowerUpBay>().Explode();
            }
            else if (collision.gameObject.GetComponent<Capsule>() != null)
            {
                Debug.Log("Capsule set to explode....");
                collision.gameObject.GetComponent<Capsule>().Explode();
            }
            Destroy();
        }

        if(collision.gameObject.tag == "PowerUp" && b_Name == "PlayerBullet")
        {
            collision.gameObject.GetComponent<PowerUp>().GeneratePower();
        }

        if (collision.gameObject.tag == "Player" && b_Name == "EnemyBullet")
        {
            collision.gameObject.GetComponent<PlayerMovement>().LoseLife();
            Debug.Log("Player Lost a life....");
            Destroy();
        }
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(b_Name);
        if (collision.gameObject.tag == "Enemy" && b_Name == "PlayerBullet")
        {
            collision.gameObject.GetComponent<Enemy>().Explode();
        }

        if (collision.gameObject.tag == "PowerUp" && b_Name == "PlayerBullet")
        {
            collision.gameObject.GetComponent<PowerUp>().GeneratePower();
        }

        if (collision.gameObject.tag == "Entities" && b_Name == "PlayerBullet")
        {
            if (collision.gameObject.GetComponent<PowerUpBay>() != null)
            {
                Debug.Log("powerbay set to explode....");
                collision.gameObject.GetComponent<PowerUpBay>().Explode();
            }
            else if (collision.gameObject.GetComponent<Capsule>() != null)
            {
                Debug.Log("Capsule set to explode....");
                collision.gameObject.GetComponent<Capsule>().Explode();
            }
            Destroy();
        }

        if (collision.gameObject.tag == "Player" && b_Name == "EnemyBullet")
        {
            collision.gameObject.GetComponent<PlayerMovement>().LoseLife();
            Debug.Log("Player Lost a life....");
            Destroy();
        }
    }


    protected void Destroy()
    {
        Destroy(this.gameObject);
    }
}
