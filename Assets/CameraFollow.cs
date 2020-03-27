using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    Transform target = null;
    Camera cm;
    Vector2 storeCamRot = Vector2.zero;

    [SerializeField] private float speedRot = 2;
    [SerializeField] private float speedMov = 2;
    [SerializeField] private float speedScroll = 2;
    [Space]
    [SerializeField] private float upDownMargin = 0.1f;
    [SerializeField] private float radius = 10;
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
        storeCamRot.x += Time.deltaTime * speedRot * -Input.GetAxis("Mouse X");
        storeCamRot.y += Time.deltaTime * speedRot * -Input.GetAxis("Mouse Y");
        storeCamRot.y = Mathf.Clamp(storeCamRot.y, upDownMargin, Mathf.PI-upDownMargin);
        radius -= Time.deltaTime * speedScroll * Input.GetAxis("Mouse ScrollWheel");

        Vector3 camTargetPos = target.position + GetPointOnSphere(storeCamRot, radius);

        RaycastHit hit;
        if (Physics.Raycast(target.position, camTargetPos - target.position, out hit, 50, layerMask)) {
            camTargetPos = hit.point;
        }

        transform.position = Vector3.Lerp(transform.position, camTargetPos, Time.deltaTime*speedMov);
        transform.LookAt(target);
    }

    private static Vector3 GetPointOnSphere(Vector2 rotation, float radius) {
        Vector3 val = Vector3.zero;
        val.x = Mathf.Cos(rotation.x) * Mathf.Sin(rotation.y);
        val.z = Mathf.Sin(rotation.x) * Mathf.Sin(rotation.y);
        val.y = Mathf.Cos(rotation.y);
        val *= radius;

        return val;
    } 

    private void SetTarget(Transform target) {
        this.target = target;
    }
}
