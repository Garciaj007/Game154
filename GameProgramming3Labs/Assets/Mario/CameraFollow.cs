﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;
    private Transform cam;

	// Use this for initialization
	void Start () {
        cam = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        cam.position = new Vector3(player.position.x, cam.position.y, cam.position.z);
	}
}
