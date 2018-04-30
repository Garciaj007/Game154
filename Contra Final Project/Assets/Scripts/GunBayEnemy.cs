using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBayEnemy : Enemy {

    protected bool open;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        anim.SetBool("Open", open);
    }

    // Use this for initialization
    protected override void PlayerEnterDetector()
    {
        open = true;
    }

    protected override void PlayerStayDetector()
    {
        if (open)
        {
            //aim and shoot at the player
            direction = player.transform.position - this.transform.position;
            direction = direction / direction.magnitude;

            anim.SetFloat("X", direction.x);
            anim.SetFloat("Y", direction.y);

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
        Debug.Log("Exploding thijjdj...");
        Destroy();
    }

    protected override void PlayerExitDetector()
    {
        open = false;
    }
}
