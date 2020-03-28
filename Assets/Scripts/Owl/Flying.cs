using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{
    Rigidbody rb;

    public float lift = 1f;
    public float drag = 1f;
    public float wingTorque = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Vector3.Dot(rb.velocity,transform.forward);
        // Lift
        Vector3 liftV = Vector3.up * speed * speed * lift;
        rb.AddRelativeForce(liftV);
        // Drag
        Vector3 velsqr = new Vector3(Mathf.Pow(rb.velocity.x, 2), Mathf.Pow(rb.velocity.y, 2), Mathf.Pow(rb.velocity.z, 2));
        Vector3 dragV = -velsqr * drag;
        rb.AddRelativeForce(dragV);
        //rb.AddRelativeForce(Vector3.back * speed * speed * drag);
        
        //Debug.Log(rb.rotation * Vector3.up +  " " + Physics.gravity);
        //rb.velocity = Physics.gravity - rb.rotation * Physics.gravity;
        rb.AddRelativeForce(Vector3.forward * 10f);


        //rb.AddRelativeTorque(Vector3.right * (Physics.gravity - liftV));
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(rb.velocity * drag);
            //rb.velocity += rb.rotation * Vector3.forward * 10f;
        }
    }
}
