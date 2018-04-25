using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBayEnemy : Enemy {

	// Use this for initialization
	protected void PlayerEnterDetector()
    {
        base.PlayerEnterDetector();

        //anim.SetBool("Open", true);
    }

    protected void PlayerStayDetector()
    {
        base.PlayerStayDetector();

        //anim.SetFloat("X", direction.x);
        //anim.SetFloat("Y", direction.y);
    }

    protected void PlayerExitDetector()
    {
        base.PlayerExitDetector();

        //anim.SetBool("Open", false);
    }
}
