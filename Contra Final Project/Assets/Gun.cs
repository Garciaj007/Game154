using UnityEngine;

public class Gun : MonoBehaviour {

    public GameObject peaShoter;

    [SerializeField]
    private bool shoot = false;
    private Transform gunBarrel;

	// Use this for initialization
	void Start () {
        gunBarrel = this.GetComponentInChildren<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (shoot)
        {
            Instantiate(peaShoter, gunBarrel);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            shoot = true;
        } else
        {
            shoot = false;
        }
	}
}
