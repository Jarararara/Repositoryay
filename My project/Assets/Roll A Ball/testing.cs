using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class testing : MonoBehaviour
{
    public GameObject cube;
    Transform t;
    float speed = .01f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        t = cube.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        t.Translate(speed, 0, 0);
        //rotation = rotation + 0.001f;
        //t.Rotate(rotation, rotation, rotation);
        if (t.position.x > 10)
        {
            speed = speed * -1;
        }
        else if (t.position.x < -10)
        {
            speed = speed * -1;
        }
    }
}
