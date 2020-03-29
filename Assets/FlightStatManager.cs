using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlightStatManager : MonoBehaviour {
    public Text jumpUIText;
    public Image jumpUIProgBar;

    // Start is called before the first frame update
    void Start() {

    }

    float tMax = 2f;
    float t = 1f;
    
    // Update is called once per frame
    void Update() {
        if (t > 0) {
            t -= Time.deltaTime;
        } else {
            t = tMax;
            Flying.Instance.spaceLeft++;
        }

        jumpUIProgBar.fillAmount = ((tMax-t) / tMax);
        jumpUIText.text = ""+Flying.Instance.spaceLeft;
    }
}
