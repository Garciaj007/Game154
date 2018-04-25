using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour {

    public Vector3 speed;
    public float time = 3.0f;

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
}
