﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompasMarkers : MonoBehaviour {
    // Start is called before the first frame update
    RectTransform rectT;
    Image img;
    [SerializeField] private float rotAngle;
    void Start() {
        rectT = GetComponent<RectTransform>();
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update() {
        if (Flying.Instance != null) {
            Vector2 idk = rectT.anchoredPosition;
            Vector3 vecPlayerForward = Vector3.Scale(Flying.Instance.transform.forward, new Vector3(1, 0, 1));
            Vector3 vecPlayerRight = Vector3.Scale(Flying.Instance.transform.right, new Vector3(1, 0, 1));
            Vector3 vecDirToTarget = Quaternion.AngleAxis(rotAngle, Vector3.forward)*new Vector3(0, 0, 1);

            float angle = Mathf.Deg2Rad * Vector3.Angle(vecDirToTarget, vecPlayerForward);
            if (Vector3.Dot(vecDirToTarget, vecPlayerRight) > 0) angle += Mathf.PI;

            //print(angle);
            idk.x = Mathf.Lerp(idk.x, (Mathf.Sin(angle)* 300 + 300) % 600, Time.deltaTime * 8f);
            rectT.anchoredPosition = idk;

            img.enabled = (angle > Mathf.PI/2f);
        }
    }
}
