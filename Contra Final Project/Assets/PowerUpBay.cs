using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBay : MonoBehaviour {

    public Detector detector;
    public Animation Explosion;

    private Animator anim;

	// Use this for initialization
	void Start () {
        detector.OnEnterListener = PlayerEnterDetector;
        detector.OnExitListener = PlayerExitDetector;

        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected void PlayerEnterDetector()
    {
        anim.SetBool("Open", true);
    }

    protected void PlayerExitDetector()
    {
        anim.SetBool("Open", false);
    }

    public void OnDestroy()
    {
        anim.SetBool("Shot", true);
        float time = anim.GetCurrentAnimatorStateInfo(0).length + Time.time;
        if (Time.time > time)
        {
            Destroy(this.gameObject);
        }
    }
}
