using UnityEngine;

public class Gun : MonoBehaviour
{

    public Bullet smallBullet;
    public Bullet BigBullet;
    public Bullet FlameBullet;
    public Bullet LaserBullet;
    public Bullet currentBullet;
    public Transform gunBarrel;

    public float speed;
    public bool spread = false;
    private bool shoot = false;
    private PlayerMovement pm;



    // Use this for initialization
    void Start()
    {
        if (gameObject.GetComponentsInChildren<Transform>()[1] != null)
        {
            gunBarrel = gameObject.GetComponentsInChildren<Transform>()[1];
        }
        else
        {
            throw new MissingComponentException("There are no Transform components in Children: " + this.ToString());
        }
        pm = GetComponent<PlayerMovement>();

        currentBullet = smallBullet;
    }

    private void Update()
    {
        shoot = Input.GetMouseButtonDown(0);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (shoot)
        {
            if (spread)
            {
                Spread();
            }
            else
            {

                if (pm.Flipped())
                {
                    currentBullet.b_Name = "PlayerBullet";
                    gunBarrel.position = new Vector3(gunBarrel.position.x - 20.0f, gunBarrel.position.y, gunBarrel.position.z);
                    Bullet bullet = Instantiate(currentBullet, gunBarrel.position, Quaternion.identity);
                    bullet.speed = speed * pm.AimDirection();
                    Debug.Log(speed * pm.AimDirection());
                }
                else
                {
                    currentBullet.b_Name = "PlayerBullet";
                    Bullet bullet = Instantiate(currentBullet, gunBarrel.position, Quaternion.identity);
                    bullet.speed = speed * pm.AimDirection();
                    Debug.Log(speed * pm.AimDirection());
                }

            }
            FindObjectOfType<AudioManager>().Play("Shoot");
        }

    }

    void Spread()
    {

        if (pm.Flipped())
        {
            currentBullet.b_Name = "PlayerBullet";
            gunBarrel.position = new Vector3(gunBarrel.position.x - 20.0f, gunBarrel.position.y, gunBarrel.position.z);
            Bullet bullet1 = Instantiate(currentBullet, gunBarrel.position, Quaternion.identity);
            Bullet bullet2 = Instantiate(currentBullet, gunBarrel.position, Quaternion.identity);
            Bullet bullet3 = Instantiate(currentBullet, gunBarrel.position, Quaternion.identity);
            bullet1.speed = speed * pm.AimDirection();
            bullet2.speed = speed * (pm.AimDirection() + Vector2.up);
            bullet3.speed = speed * (pm.AimDirection() + Vector2.down);
        }
        else
        {
            currentBullet.b_Name = "PlayerBullet";
            Bullet bullet1 = Instantiate(currentBullet, gunBarrel.position, Quaternion.identity);
            Bullet bullet2 = Instantiate(currentBullet, gunBarrel.position, Quaternion.identity);
            Bullet bullet3 = Instantiate(currentBullet, gunBarrel.position, Quaternion.identity);
            bullet1.speed = speed * pm.AimDirection();
            bullet2.speed = speed * (pm.AimDirection() + Vector2.up);
            bullet3.speed = speed * (pm.AimDirection() + Vector2.down);
        }

    }
}
