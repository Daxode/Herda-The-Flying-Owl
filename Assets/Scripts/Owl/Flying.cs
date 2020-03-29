using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{
    Rigidbody rb;

    public float lift = 1f;
    public float drag = 1f;
    public float wingTorque = 0.1f;
    public float spaceForce = 100f;

    public int spaceLeft = 5;

    private float clift = 0f;

    private static MovementFlying _instance;
    public static MovementFlying Instance { get { return _instance; } }

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
        rb = GetComponent<Rigidbody>();
    }
    bool spacePress = false;
    // Update is called once per frame
    void FixedUpdate()
    {
        //rb.velocity = Vector3.zero;
        //rb.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, rb.velocity, wingTorque, 0f));

        float speed = Vector3.Dot(rb.velocity,transform.forward);
        // Lift
        Vector3 liftV = Vector3.up * speed * speed * clift;
        rb.AddRelativeForce(liftV);
        // Drag
        Vector3 dragV = - rb.velocity.normalized * Mathf.Pow(rb.velocity.magnitude, 2) * drag;
        rb.AddRelativeForce(dragV);

        // Lift
        rb.AddRelativeForce(Vector3.forward);
        Debug.Log(transform.forward.y);

        
        //rb.AddRelativeForce(Vector3.back * speed * speed * drag);

        //Debug.Log(rb.rotation * Vector3.up +  " " + Physics.gravity);
        //rb.velocity = Physics.gravity - rb.rotation * Physics.gravity;



        //rb.AddRelativeTorque(Vector3.right * speed * wingTorque);

        float pitch = 0;
        float roll = 0;
        if (Input.GetKey(KeyCode.Space) && spaceLeft > 0)
        {
            if (!spacePress) {
                rb.AddRelativeForce(transform.forward * spaceForce, ForceMode.Impulse);
            }
            spacePress = true;
            clift = lift;
            //rb.AddRelativeForce(rb.velocity * drag);
            //rb.velocity += rb.rotation * Vector3.forward * 10f;
            spaceLeft--;
        } else {
            spacePress = false;
            clift = 0f;
        }
        if (Input.GetKey(KeyCode.S)) {
            pitch = 1f;
        }
        if (Input.GetKey(KeyCode.W))
        {
            pitch += -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            roll = 1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            roll += -1f;
        }

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
        rb.rotation = Quaternion.Lerp(rb.rotation,
            Quaternion.LookRotation(rb.velocity + transform.up * pitch * speed + transform.right * roll, Vector3.up + transform.right * roll),
            wingTorque
        );

        //rb.rotation = Quaternion.LookRotation(
        //    Vector3.RotateTowards(transform.forward, rb.velocity + transform.up * pitch * speed + transform.right * roll, wingTorque, 0f)
        //);
        //float angle = Vector3.Angle(new Vector3(transform.forward.x, 0, 1), new Vector3(rb.velocity.x, 0, 1));
        //Quaternion newRot = Quaternion.Euler(new Vector3(rb.rotation.eulerAngles.x, rb.rotation.eulerAngles.y, angle));
        //rb.rotation = Quaternion.Lerp(rb.rotation, newRot, wingTorque);
    }
}
