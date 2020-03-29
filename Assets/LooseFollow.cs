using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseFollow : MonoBehaviour
{
    public float posSpeed = 10f;
    public float rotSpeed = 3f;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, posSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, rotSpeed * Time.deltaTime);
    }
}
