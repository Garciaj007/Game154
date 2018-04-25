using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushEnemy : Enemy {

	protected void PlayerEnterDetector()
    {
        base.PlayerEnterDetector();

        anim.SetBool("Fire", true);
    }

    protected void PlayerExitDetector()
    {
        base.PlayerExitDetector();

        anim.SetBool("Fire", false);
    }
}
