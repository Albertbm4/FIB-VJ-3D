using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMovement : MonoBehaviour {
    public float speed;

    void Start () {
        GetComponent<Rigidbody>().velocity = transform.forward * 150;
    }
    
}
