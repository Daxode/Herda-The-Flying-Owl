using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehind : MonoBehaviour {
    Transform target = null;
    Camera cm;
    Vector3 storeCamRot = Vector3.zero;

    [SerializeField] private float speedRot = 2;
    [SerializeField] private float speedMov = 2;
    [SerializeField] private float speedScroll = 2;
    [Space]
    [SerializeField] private float radius = 2;
    [SerializeField] private LayerMask layerMask = 10;
    // Start is called before the first frame update
    void Start() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        cm = Camera.main;
        SetTarget(GameObject.FindGameObjectWithTag("Player").transform);
    }

    // Update is called once per frame
    void Update() {
        storeCamRot.x -= Time.deltaTime * speedRot * Input.GetAxis("Mouse X");
        storeCamRot.y -= Time.deltaTime * speedRot * Input.GetAxis("Mouse Y") - Time.deltaTime * speedMov * Input.GetAxis("Vertical");
        storeCamRot.z -= Time.deltaTime * speedMov * Input.GetAxis("Horizontal");
        radius -= Time.deltaTime * speedScroll * Input.GetAxis("Mouse ScrollWheel");

        target.rotation = Quaternion.Euler(storeCamRot.y, storeCamRot.x, storeCamRot.z);

        transform.position = target.position - target.forward*radius + target.up*2f;
        transform.LookAt(target, target.up);
    }

    private void SetTarget(Transform target) {
        this.target = target;
    }
}
