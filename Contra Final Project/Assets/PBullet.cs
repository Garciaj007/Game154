using UnityEngine;

public class PBullet : Bullet
{

    protected override void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            //collision.gameObject.GetComponent<Enemy>();
        }
    }
}
