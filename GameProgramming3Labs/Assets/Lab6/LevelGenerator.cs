using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class LevelGenerator : MonoBehaviour
{

    public GameObject cube;
    [Space]
    public float gap = 10.0f;
    public float colorUpdateSpeed = 0.001f;

    [Header("Local Position")]
    public Transform startPos;
    public Transform endPos;

    [Header("Colors")]
    public Material m_Mat;
    public Color c_Light;
    public Color c_Dark;

    private float t = 0.0f;
    private bool b_light = true;

    // Use this for initialization
    void Start()
    {
        for (float i = startPos.localPosition.x; i < endPos.localPosition.x; i += gap)
        {
            for (float j = startPos.localPosition.y; j > endPos.localPosition.y; j -= gap)
            {
                for (float k = startPos.localPosition.z; k > endPos.localPosition.z; k -= (gap * 4))
                {
                    Instantiate(cube, new Vector3(i * Random.Range(0.5f, 3.0f), j * Random.Range(0.5f, 3.0f), k * Random.Range(0.5f, 3.0f)), Quaternion.identity);
                }
            }
        }
    }

    void Update()
    {
        t += colorUpdateSpeed;

        if (t < 1.0f && b_light)
        {
            m_Mat.color = Color.Lerp(c_Light, c_Dark, t);
        } else if ( t < 1.0f && b_light == false)
        {
            m_Mat.color = Color.Lerp(c_Dark, c_Light, t);
        } else
        {
            t = 0.0f;
            b_light = !b_light;
        }
    }
}
