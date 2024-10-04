using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelaration : MonoBehaviour
{
    public Vector3 g = Vector3.zero;
    public Vector3 v0 = new Vector3(0,10,0);
    public Vector3 currV = Vector3.zero;
    public Vector2 boundary = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= boundary.y * -1)
        {
            currV.y = 0;
            transform.position = new Vector3(0,-4.2f,0);
        }
        else
        {
            currV += g;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            AddforceUpside();
        }
        transform.position += currV * Time.deltaTime;
    }
    void AddforceUpside()
    {
        currV += v0;
    }
}
