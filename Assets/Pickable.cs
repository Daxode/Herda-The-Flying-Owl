using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour {
    private void Update()
    {
        if (transform.position.y < -1000) {
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
