using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    public Sprite[] sprites;

    private SpriteRenderer sp;
    private int choice;
    private string powerdecision;

    private GameObject player;
    private Gun gun;

    // Use this for initialization
    void Start () {
        sp = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
        gun = player.GetComponent<Gun>();

        choice = Random.Range(0, sprites.Length);

        switch (choice){
            case 0: powerdecision = "Spread";
                sp.sprite = sprites[0];
                break;
            case 1: powerdecision = "FlameThrower";
                sp.sprite = sprites[1];
                break;
            case 2: powerdecision = "Laser";
                sp.sprite = sprites[2];
                break;
            case 3: powerdecision = "MachineGun";
                sp.sprite = sprites[3];
                break;
            case 4: powerdecision = "RapidFire";
                sp.sprite = sprites[4];
                break;
            default: powerdecision = "default";
                break;
        }
	}

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Bullet>().b_Name == "PlayerBullet")
        {
            // we want to give the player the powerup...
            Invoke(powerdecision, 0f);
        }
    }

    public void GeneratePower()
    {
        Invoke(powerdecision, 0.1f);
    }

    protected void MachineGun()
    {
        gun.currentBullet = gun.BigBullet;
        Destroy();
    }

    protected void Laser()
    {
        gun.currentBullet = gun.LaserBullet;
        Destroy();
    }

    protected void FlameThrower()
    {
        gun.currentBullet = gun.FlameBullet;
        Destroy();
    }

    protected void Spread()
    {
        gun.spread = true;
        Destroy();
    }

    protected void Destroy()
    {
        Destroy(this.gameObject);
    }
}
