using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;
    public Sprite background;

    private Camera cam;
    private Vector2 screenSize;

    // Use this for initialization
    void Start () {
        cam = GetComponent<Camera>();
        screenSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }
	
	// Update is called once per frame
	void Update () {
        float xPos = cam.transform.position.x;

        if(player.position.x < -background.bounds.extents.x + screenSize.x )
        {
            xPos = -background.bounds.extents.x + screenSize.x;
        }
        else if(player.position.x > background.bounds.extents.x - screenSize.x)
        {
            xPos = background.bounds.extents.x - screenSize.x;
        } else 
        {
            xPos = player.position.x;
        }

        cam.transform.position = new Vector3(xPos, cam.transform.position.y, cam.transform.position.z);
	}
}
