using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushGunnerEnemy : Enemy {

    protected override void PlayerEnterDetector()
    {
        anim.SetBool("Fire", true);
    }

    protected override void PlayerStayDetector()
    {
        direction = Vector3.left;

        if (Time.time >= totalTime)
        {
            smallBullet.b_Name = "EnemyBullet";
            Bullet bullet = Instantiate(smallBullet, this.transform.position, Quaternion.identity);
            bullet.speed = speed * direction;
            totalTime = Time.time + fireRate;

            FindObjectOfType<AudioManager>().Play("Shoot");
        }
    }

    protected override void PlayerExitDetector()
    {
        anim.SetBool("Fire", false);
    }

    public override void Explode()
    {
        Debug.Log("Exploading...");
        Destroy();
    }
}
