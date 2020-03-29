using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        print("debugIn");
        Graber grab = other.GetComponent<Graber>();
        grab?.HandleEnterTrigger(this);
    }

    private void OnTriggerExit(Collider other){
        print("debugOut");
        Graber grab = other.GetComponent<Graber>();
        grab?.HandleExitTrigger(this);
    }
}
