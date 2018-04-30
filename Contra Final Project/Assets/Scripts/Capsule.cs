using UnityEngine;

public class Capsule : MonoBehaviour {

    public Vector3 speed;
    public PowerUp powerUp;
    public float time = 3.0f;
    public float force;

    private float totalTime;

	// Use this for initialization
	void Start () {
        totalTime = Time.time + time;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position += speed;
        if(Time.time > totalTime)
        {
            speed.y = -speed.y;
            totalTime = Time.time + time;
        }
	}

    public void Explode()
    {
        //anim.SetBool("Shot", true);
        DisplayPowerup();
    }

    public void DisplayPowerup()
    {
        PowerUp power = Instantiate(powerUp, transform.position, Quaternion.identity);
        Rigidbody2D rigid = power.GetComponent<Rigidbody2D>();
        rigid.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        Destroy();
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
