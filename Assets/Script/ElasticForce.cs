using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElasticForce : MonoBehaviour
{
    public GameObject origin;
    public float k;
    public float springLength;
    public Vector3 gravity = new Vector3(0, 0.1f, 0);
    public float mass;

    private Vector3 acc;
    private Vector3 vel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            Vector3 cursor = Input.mousePosition;
            cursor.z = Camera.main.transform.position.z*-1;
            Vector3 CursorPoint = Camera.main.ScreenToWorldPoint(cursor);
            //Debug.Log(CursorPoint);
            transform.position = CursorPoint;
        }
        Vector3 elasticForce = transform.position - origin.transform.position;
        float dx = Vector3.Magnitude(elasticForce) - springLength;
        //Debug.Log(dx);
        elasticForce = elasticForce.normalized;
       // Debug.Log(elasticForce);
        elasticForce *= -1 * k * dx;
       // Debug.Log(elasticForce);

        acc = elasticForce/mass;
        acc += gravity;
        vel += acc;

        transform.position += vel * Time.deltaTime;
        vel *= 0.99f;
    }
}
