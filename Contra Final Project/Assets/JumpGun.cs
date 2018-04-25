using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGun : Enemy {

	protected void PlayerStayDetector()
    {
        base.PlayerStayDetector();

        //anim.SetInteger("Aim", (int) direction.y);
    }
}
