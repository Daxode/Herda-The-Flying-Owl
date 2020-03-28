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
    void FixedUpdate()
    {
        //rb.velocity = Vector3.zero;
        //rb.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, rb.velocity, wingTorque, 0f));

        float speed = Vector3.Dot(rb.velocity,transform.forward);
        // Lift
        Vector3 liftV = Vector3.up * speed * speed * lift;
        rb.AddRelativeForce(liftV);
        // Drag
        Vector3 dragV = - rb.velocity.normalized * Mathf.Pow(rb.velocity.magnitude, 2) * drag;
        rb.AddRelativeForce(dragV);
        //rb.AddRelativeForce(Vector3.back * speed * speed * drag);

        //Debug.Log(rb.rotation * Vector3.up +  " " + Physics.gravity);
        //rb.velocity = Physics.gravity - rb.rotation * Physics.gravity;



        //rb.AddRelativeTorque(Vector3.right * speed * wingTorque);

        float pitch = 0;
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.forward * 10f);
            //rb.AddRelativeForce(rb.velocity * drag);
            //rb.velocity += rb.rotation * Vector3.forward * 10f;
        } else if (Input.GetKey(KeyCode.W)) {
            pitch = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            pitch = -1;
        }
        rb.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, rb.velocity, wingTorque, 0f));
    }
}
