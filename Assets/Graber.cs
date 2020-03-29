using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class Graber : MonoBehaviour {
    private static Graber _instance;
    public static Graber Instance { get { return _instance; } }

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


    Dictionary<int, Pickable> pickers;

    Transform picked = null;
    // Start is called before the first frame update
    void Start() {
        pickers = new Dictionary<int, Pickable>();
    }

    public Animator anim;

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (picked == null) { //Try to pick
                anim.SetTrigger("DoGrab");
                if (pickers.Count > 0) {
                    picked = pickers.First().Value.transform;

                    foreach (var col in picked.GetComponents<Collider>()) {
                        col.enabled = false;
                    }
                    
                    Animator anim = picked.GetComponentInChildren<Animator>();
                    if (anim != null) anim.enabled = false;
                }
            } else {
                foreach (var col in picked.GetComponents<Collider>()) {
                    col.enabled = true;
                }

                Animator anim = picked.GetComponentInChildren<Animator>();
                if (anim != null) anim.enabled = true;
                picked.rotation = Quaternion.identity;
                picked = null;
            } 
        }

        if (picked != null) {
            picked.position = transform.position - transform.up*2.0f - transform.forward * 0.3f;
            picked.rotation = transform.rotation;
        }
    }

    public void HandleEnterTrigger(Pickable pick) {
        pickers.Add(pick.GetInstanceID(), pick);
    }

    public void HandleExitTrigger(Pickable pick) {
        pickers.Remove(pick.GetInstanceID());
    }

    private void OnCollisionEnter(Collision collision) {
        print("idk" + collision.gameObject.layer);
        if (collision.gameObject.layer != 10) return;
        SceneManager.LoadScene("StartScene");
    }
}