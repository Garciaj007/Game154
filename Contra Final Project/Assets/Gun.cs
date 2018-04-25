using UnityEngine;

public class Gun : MonoBehaviour {

    public Bullet smallBullet;
    public Bullet BigBullet;
    public Transform gunBarrel;

    public float speed;

    private bool shoot = false;
    private PlayerMovement pm;

	// Use this for initialization
	void Start () {
        if (gameObject.GetComponentsInChildren<Transform>()[1] != null)
        {
            gunBarrel = gameObject.GetComponentsInChildren<Transform>()[1];
        } else
        {
            throw new MissingComponentException("There are no Transform components in Children: " + this.ToString());
        }
        pm = GetComponent<PlayerMovement>();
	}

    private void Update()
    {
        shoot = Input.GetMouseButtonDown(0);
    }

    // Update is called once per frame
    void LateUpdate () {
        if (shoot)
        {
            if (pm.Flipped())
            {
                gunBarrel.position = new Vector3(gunBarrel.position.x - 20.0f, gunBarrel.position.y, gunBarrel.position.z);
                Bullet bullet = Instantiate(smallBullet, gunBarrel.position, Quaternion.identity);
                bullet.speed = speed * pm.AimDirection();
                Debug.Log(speed * pm.AimDirection());
            } else
            {
                Bullet bullet = Instantiate(smallBullet, gunBarrel.position, Quaternion.identity);
                bullet.speed = speed * pm.AimDirection();
                Debug.Log(speed * pm.AimDirection());
            }   
        }    
	}
}
