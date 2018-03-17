using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    public Transform downStairs;
    public Transform upStairs;

    private bool onTeleport = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Downstairs")
        {
            if (onTeleport == false)
            {
                onTeleport = true;
                this.transform.position = upStairs.position;
            }
            else
            {
                onTeleport = false;
            }
        }

        if (collision.gameObject.name == "Upstairs")
        {
            if (onTeleport == false)
            {
                onTeleport = true;
                this.transform.position = downStairs.position;
            }
            else
            {
                onTeleport = false;
            }
        }
    }
}
