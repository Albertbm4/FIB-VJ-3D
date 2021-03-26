using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {
    
    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("PlayerFire") || other.CompareTag("EnemyFire") || other.CompareTag("Venom")) {
            Destroy(other.gameObject);
        }
    }

}
