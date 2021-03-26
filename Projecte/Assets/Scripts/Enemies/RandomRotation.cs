using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour {

    void Start(){
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * 1.5f; 
    }

}
