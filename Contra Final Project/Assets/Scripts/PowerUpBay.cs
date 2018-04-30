using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBay : MonoBehaviour {

    public Detector detector;
    private Animator anim;

    public PowerUp powerUp;
    public float force;

	// Use this for initialization
	void Start () {
        detector.OnEnterListener = PlayerEnterDetector;
        detector.OnExitListener = PlayerExitDetector;

        anim = GetComponent<Animator>();
	}

    protected void PlayerEnterDetector()
    {
        anim.SetBool("Open", true);
    }

    protected void PlayerExitDetector()
    {
        anim.SetBool("Open", false);
    }

    public void Explode()
    {
        anim.SetBool("Shot", true);
        DisplayPowerup();
    }

    public void DisplayPowerup()
    {
        Vector3 pos = transform.position;
        PowerUp power = Instantiate(powerUp, pos, Quaternion.identity);
        Rigidbody2D rigid = power.GetComponent<Rigidbody2D>();
        rigid.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        Invoke("Destroy", 0.5f);
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
