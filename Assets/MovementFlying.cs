using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementFlying : MonoBehaviour {
    Rigidbody rb;
    private static MovementFlying _instance;
    public static MovementFlying Instance { get { return _instance; } }


    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(gameObject);
        } else {
            _instance = this;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.velocity = Physics.gravity;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity += transform.forward * 500f + transform.up * 250f;
            }
            else if (Input.GetKey(KeyCode.Space))
            {
                rb.velocity = Physics.gravity * 0.5f;
            }
    }
}