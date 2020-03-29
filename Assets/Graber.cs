using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Graber : MonoBehaviour {
    Dictionary<int, Pickable> pickers;

    Transform picked = null;
    // Start is called before the first frame update
    void Start() {
        pickers = new Dictionary<int, Pickable>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (picked == null) { //Try to pick
                if (pickers.Count > 0) {
                    picked = pickers.First().Value.transform;
                    Animator anim = picked.GetComponentInChildren<Animator>();
                    if (anim != null) anim.enabled = false;
                }
            } else {
                Animator anim = picked.GetComponentInChildren<Animator>();
                if (anim != null) anim.enabled = true;
                picked = null;
            } 
        }

        if (picked != null) {
            picked.position = transform.position;
        }
    }

    public void HandleEnterTrigger(Pickable pick) {
        pickers.Add(pick.GetInstanceID(), pick);
    }

    public void HandleExitTrigger(Pickable pick) {
        pickers.Remove(pick.GetInstanceID());
    }
}