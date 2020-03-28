using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementFlying : MonoBehaviour {
    private static MovementFlying _instance;
    public static MovementFlying Instance { get { return _instance; } }


    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(gameObject);
        } else {
            _instance = this;
        }
    }
}