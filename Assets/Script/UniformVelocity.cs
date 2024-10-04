using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniformVelocity : MonoBehaviour
{

    public bool useVector = false;
    public float vx = 1f;
    public float vy = 1f;

    public Vector2 boundary;

    private Vector3 v = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        v.x = vx;
        v.y = vy;

        switch (useVector)
        {
            case false:
                Vector3 pos = transform.position;
                pos.x += vx * Time.deltaTime;
                pos.y += vy * Time.deltaTime;
                transform.position = pos;
                break;
            case true:
                transform.position += v * Time.deltaTime;
                break;
        }
        if (transform.position.x > boundary.x || transform.position.x < boundary.x * -1) vx *= -1;
        if (transform.position.y > boundary.y || transform.position.y < boundary.y * -1) vy *= -1;
    }
}
