using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class compasTarget : MonoBehaviour {
    // Start is called before the first frame update
    RectTransform rectT;
    Image img;
    [SerializeField] private Transform target;
    bool isRdy = false;
    void Start() {
        rectT = GetComponent<RectTransform>();
        img = GetComponent<Image>();
    }

    public void SetTarget(Transform target) {
        this.target = target;
    }
    public void SetRdyFlag(bool rdy){
        isRdy = rdy;
    }

    // Update is called once per frame
    void Update() {
        if (target != null && isRdy) {
            Vector2 idk = rectT.anchoredPosition;
            Vector3 vecPlayerForward = Vector3.Scale(MovementFlying.Instance.transform.forward, new Vector3(1, 0, 1));
            Vector3 vecPlayerRight = Vector3.Scale(MovementFlying.Instance.transform.right, new Vector3(1, 0, 1));
            Vector3 vecDirToTarget = Vector3.Scale(MovementFlying.Instance.transform.position - target.position, new Vector3(1, 0, 1));

            float angle = Mathf.Deg2Rad * Vector3.Angle(vecDirToTarget, vecPlayerForward);
            if (Vector3.Dot(vecDirToTarget, vecPlayerRight) > 0) angle += Mathf.PI;

            print(angle);
            idk.x = Mathf.Lerp(idk.x, (Mathf.Sin(angle)*250+250)%500, Time.deltaTime * 8f);
            rectT.anchoredPosition = idk;

            Color c = img.color;
            c.g = (((angle+Mathf.PI)%Mathf.PI) /(Mathf.PI));
            c.r = 1 - c.g;

            img.color = c;
        }
    }
}
