using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Detector detector;
    [HideInInspector]
    public GameObject player;
    [HideInInspector]
    public Transform gunBarrel;
    public Bullet smallBullet;

    public float fireRate = 3.0f;
    public float speed = 5.0f;

    protected Animator anim;
    protected Vector3 direction;
    protected float totalTime;
    protected bool shoot;

    // Use this for initialization
    protected virtual void Start()
    {
        anim = GetComponent<Animator>();

        detector.OnEnterListener = PlayerEnterDetector;
        detector.OnStayListener = PlayerStayDetector;
        detector.OnExitListener = PlayerExitDetector;

        player = GameObject.FindGameObjectWithTag("Player");

        totalTime = Time.time + fireRate;
    }

    public virtual void Destroy()
    {
        Destroy(gameObject);
    }

    //Unimplemented virtual functions
    public virtual void Explode() { }

    protected virtual void Update() { }
    protected virtual void PlayerEnterDetector() { }
    protected virtual void PlayerStayDetector() { }
    protected virtual void PlayerExitDetector() { }
}
