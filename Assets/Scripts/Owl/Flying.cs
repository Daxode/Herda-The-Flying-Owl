﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{
    Rigidbody rb;

    //public float lift = 1f;
    //public float drag = 1f;
    public float pitchT = 50f;
    public float rollT = 50f;
    public float rollAmount = 50;
    public float yawT = 50f;
    //public float spaceForce = 100f;
    private float speed = 10f;
    public float sspeed = 10f;
    public float cspeed = 10f;
    public float speedtime = 1f;
    private float timeleft = 0f;

    public int spaceLeft = 5;

    public Animator anim;
    

    //private float clift = 0f;

    private static Flying _instance;
    public static Flying Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
        cspeed = speed;
    }
    bool spacePress = false;
    // Update is called once per frame
    void FixedUpdate()
    {
        //rb.velocity = Vector3.zero;
        //rb.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, rb.velocity, wingTorque, 0f));

        //float speed = Vector3.Dot(rb.velocity,transform.forward);
        // Lift
        //Vector3 liftV = Vector3.up * speed * speed * clift;
        //rb.AddRelativeForce(liftV);
        // Drag
        //Vector3 dragV = - rb.velocity.normalized * Mathf.Pow(rb.velocity.magnitude, 2) * drag;
        //rb.AddRelativeForce(dragV);

        // Lift
        //rb.AddRelativeForce(Vector3.forward);
        //Debug.Log(transform.forward.y);


        //rb.AddRelativeForce(Vector3.back * speed * speed * drag);

        //Debug.Log(rb.rotation * Vector3.up +  " " + Physics.gravity);
        //rb.velocity = Physics.gravity - rb.rotation * Physics.gravity;



        //rb.AddRelativeTorque(Vector3.right * speed * wingTorque);
        timeleft -= Time.fixedDeltaTime;
        float pitch = 0;
        float roll = 0;
        if (Input.GetKey(KeyCode.Space) && spaceLeft > 0)
        {
            if (!spacePress) {
                //rb.AddRelativeForce(transform.forward * spaceForce, ForceMode.Impulse);
                spaceLeft--;
                anim.SetTrigger("DoFlap");
                cspeed = sspeed;
                timeleft = speedtime;
            }
            spacePress = true;
            //clift = lift;
            //rb.AddRelativeForce(rb.velocity * drag);
            //rb.velocity += rb.rotation * Vector3.forward * 10f;
            
        }

        if (timeleft < 0)
        {
            spacePress = false;
            cspeed = speed;
        }
        pitch = Input.GetAxis("Vertical");
        roll = Input.GetAxis("Horizontal");
        rb.velocity = rb.rotation * Vector3.forward * cspeed;
        //rb.AddRelativeTorque(Vector3.right * wingTorque * (Vector3.Dot(Vector3.forward, rb.rotation * Vector3.forward)));

        //rb.velocity += transform.forward * transform.forward.y;
        //rb.velocity = -(rb.rotation * Vector3.forward) * (rb.rotation * Vector3.forward).y;
        //rb.velocity += - Vector3.forward * transform.forward.y + Vector3.up * speed * lift + Vector3.forward * speed * drag;

        //Vector3 x = Vector3.Cross(transform.forward.normalized, (rb.velocity + transform.up * speed).normalized);
        //float theta = Mathf.Asin(x.magnitude);
        //Vector3 w = x.normalized * theta / Time.fixedDeltaTime;
        //Quaternion q = transform.rotation * rb.inertiaTensorRotation;
        //Vector3 T = q * Vector3.Scale(rb.inertiaTensor, (Quaternion.Inverse(q) * w)) * wingTorque;
        //rb.AddTorque(T);

        //Vector3 lr = transform.forward + rb.rotation * Vector3.up * pitch;
        //Vector3 lr = new Vector3(0, pit, 1);
        //rb.rotation = Quaternion.Euler(
        //    Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, rb.velocity + transform.up * speed, wingTorque, 0f)).eulerAngles.x + pitch * speed,
        //    rb.rotation.eulerAngles.y,
        //    Vector3.Lerp(rb.rotation.eulerAngles, new Vector3(rb.rotation.eulerAngles.x, rb.rotation.eulerAngles.y, roll), wingTorque).z
        //);
        // Quaternion.LookRotation(Vector3.RotateTowards(transform.up, Vector3.up + transform.right * roll, wingTorque, 0f)).eulerAngles.z
        //Debug.Log(Quaternion.LookRotation(Vector3.RotateTowards(transform.up, Vector3.up + transform.right * roll, wingTorque, 0f)).eulerAngles);

        /*rb.rotation = Quaternion.Lerp(rb.rotation,
            Quaternion.LookRotation(rb.velocity + transform.up * pitch * speed, Vector3.up + transform.right * roll),
            wingTorque
        );*/

        /*rb.rotation = Quaternion.Lerp(rb.rotation,
            Quaternion.Euler(-pitch *pitchT, roll*yawT, -roll*rollT),
            wingTorque
        );*/

        /*rb.rotation = Quaternion.Lerp(rb.rotation,
            Quaternion.AngleAxis(-pitch * pitchT, Vector3.right) * Quaternion.AngleAxis(roll * yawT, Vector3.up) * Quaternion.AngleAxis(-roll * rollT, Vector3.forward),
            wingTorque
        );*/

        /*float rollAngle = rb.rotation.eulerAngles.z + roll * rollAmount;//Quaternion.Angle(rb.rotation, Quaternion.AngleAxis(-roll * (rb.rotation.z - rollAmount), Vector3.forward));
        Quaternion rollQ = Quaternion.AngleAxis(rollT * rollAngle, Vector3.forward);
        rb.rotation *= Quaternion.AngleAxis(-pitch * pitchT, Vector3.right) 
                    * Quaternion.AngleAxis(roll * yawT, Vector3.up) 
                    * rollQ;
        Debug.Log(rollAngle);*/

        rb.rotation = Quaternion.Lerp(rb.rotation,
            Quaternion.Euler(rb.rotation.eulerAngles.x + pitchT * pitch, rb.rotation.eulerAngles.y + yawT * roll, -rollAmount * roll),
        rollT);

        //rb.rotation = Quaternion.LookRotation(
        //    Vector3.RotateTowards(transform.forward, rb.velocity + transform.up * pitch * speed + transform.right * roll, wingTorque, 0f)
        //);

        //float angle = Vector3.Angle(new Vector3(transform.forward.x, 0, 1), new Vector3(rb.velocity.x, 0, 1));
        //Quaternion newRot = Quaternion.Euler(new Vector3(rb.rotation.eulerAngles.x, rb.rotation.eulerAngles.y, angle));
        //rb.rotation = Quaternion.Lerp(rb.rotation, newRot, wingTorque);
    }
}
