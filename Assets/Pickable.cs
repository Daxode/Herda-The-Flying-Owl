using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour {
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        rb.velocity = Physics.gravity;
        if (transform.position.y < -1000) {
            Graber.Instance.HandleExitTrigger(this);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other) {
        //print("debugIn");
        Graber grab = other.GetComponent<Graber>();
        grab?.HandleEnterTrigger(this);
    }

    private void OnTriggerExit(Collider other){
        //print("debugOut");
        Graber grab = other.GetComponent<Graber>();
        grab?.HandleExitTrigger(this);
    }
}
