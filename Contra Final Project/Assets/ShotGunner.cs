using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunner : Enemy {

    protected void PlayerStayDetector()
    {
        base.PlayerEnterDetector();

        anim.SetInteger("Aim", (int) direction.y);
    }
}
