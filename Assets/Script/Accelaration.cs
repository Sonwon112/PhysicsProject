using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Accelaration : MonoBehaviour
{
    private Vector3 vel = Vector3.zero;
    private Vector3 acc;
    private Vector3 force;
    
    public float mass = 1f;
    public float gravity = 9.8f;
    public float boundary = 4.2f;
    public Vector3 windForce = new Vector3 (0, 0.1f, 0);

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        force = new Vector3(0, gravity * mass, 0);
        if (Input.GetKeyDown(KeyCode.D)) force += windForce;
        if (Input.GetKeyDown(KeyCode.A)) force -= windForce;

        acc = force / mass;
        Vector3 v0 = vel;
        vel += acc;
        Vector3 avg = (vel + v0) * 0.5f;
        
        transform.position += avg*Time.deltaTime;

        if (transform.position.y < boundary * -1 && vel.y < 0)
        {
            vel.y = vel.y * -1;
        }

        acc = Vector3.zero;
    }



}
