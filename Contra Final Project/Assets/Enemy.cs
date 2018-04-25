using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Animation Explode;
    public Detector detector;
    public GameObject player;
    public Transform gunBarrel;
    public Bullet smallBullet;

    public float fireRate = 3.0f;
    public float speed = 10.0f;

    protected Animator anim;
    protected Vector3 direction;
    protected float totalTime;
    protected bool shoot;

	// Use this for initialization
	protected void Start () {
        detector.OnEnterListener = PlayerEnterDetector;
        detector.OnStayListener = PlayerStayDetector;
        detector.OnExitListener = PlayerExitDetector;

        anim = GetComponent<Animator>();

        if(GetComponents<Transform>()[1] != null)
        {
            gunBarrel = GetComponents<Transform>()[1];
        }

        totalTime = Time.time + fireRate;
	}
	
	// Update is called once per frame
	protected void Update () {
		
	}

    public void OnDestroy()
    {
        Animation ex = Instantiate<Animation>(Explode, transform.position, Quaternion.identity);
        ex.Play();
        Destroy(this.gameObject);
    }

    protected void PlayerEnterDetector()
    {
        //go from Closed to Open
    }

    protected void PlayerStayDetector()
    {
        //aim and shoot at the player
        direction = this.transform.position - player.transform.position;
        direction = direction / direction.magnitude;

        if(Time.time >= totalTime)
        {
            Bullet bullet = Instantiate(smallBullet, gunBarrel.position, Quaternion.identity);
            bullet.speed = speed * direction;
            totalTime = Time.time + fireRate;
        }
    }

    protected void PlayerExitDetector()
    {
        //go from open state to closed state
    }
}
