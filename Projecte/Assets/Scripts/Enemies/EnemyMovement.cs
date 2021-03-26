using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public float speed;

    void Start () {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    void update () {
        transform.position += new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
    }

}
