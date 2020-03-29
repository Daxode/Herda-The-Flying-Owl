using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptAddTracker : MonoBehaviour {
    public GameObject compasTarget;
    public Sprite showThis;
    // Start is called before the first frame update
    void Start() {
        GameObject ct = Instantiate(compasTarget, GameObject.FindWithTag("MarkerViewer").transform);
        Image im = ct.GetComponent<Image>();

        im.sprite = showThis;
        ct.GetComponent<CompasTarget>().SetTarget(transform);
    }

    // Update is called once per frame
    void Update() {
        
    }
}
