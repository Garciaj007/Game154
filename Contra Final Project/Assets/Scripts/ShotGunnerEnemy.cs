using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunnerEnemy : Enemy
{
    protected override void PlayerStayDetector()
    {
        direction = player.transform.position - this.transform.position;
        direction = direction / direction.magnitude;

        if (direction.x < 0)
        {
            if (direction.y <= 0.5 && direction.y >= -0.5)
            {
                direction = Vector3.left;
                anim.SetFloat("Aim", 0);
            }
            else if (direction.y > 0.5)
            {
                direction = new Vector2(-1, 1);
                anim.SetFloat("Aim", 1);
            }
            else if (direction.y < -0.5)
            {
                direction = new Vector2(-1, -1);
                anim.SetFloat("Aim", -1);
            }

            if (Time.time >= totalTime)
            {
                smallBullet.b_Name = "EnemyBullet";
                Bullet bullet = Instantiate(smallBullet, this.transform.position, Quaternion.identity);
                bullet.speed = speed * direction;
                totalTime = Time.time + fireRate;
                FindObjectOfType<AudioManager>().Play("Shoot");
            }
        }
    }

    public override void Explode()
    {
        Debug.Log("Explosisoisisis");
        Destroy();
    }
}
