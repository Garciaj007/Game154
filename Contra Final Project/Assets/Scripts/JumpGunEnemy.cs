using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGunEnemy : Enemy {

    protected override void PlayerEnterDetector()
    {
        anim.SetBool("Spawned", true);
    }

    protected override void PlayerStayDetector()
    {
        direction = player.transform.position - this.transform.position;
        direction = direction / direction.magnitude;

        if (direction.x <= 0 && direction.y >= 0)
        {
            
            if (Time.time >= totalTime)
            {
                smallBullet.b_Name = "EnemyBullet";
                Bullet bullet = Instantiate(smallBullet, this.transform.position, Quaternion.identity);
                bullet.speed = speed * direction;
                totalTime = Time.time + fireRate;
                FindObjectOfType<AudioManager>().Play("Shoot");
            }
        }

        anim.SetFloat("AimY", direction.y);
    }

    public override void Explode()
    {
        Debug.Log("Exploding...");
        Destroy();
    }

    protected override void PlayerExitDetector()
    {
        anim.SetBool("Spawned", false);
    }
}
