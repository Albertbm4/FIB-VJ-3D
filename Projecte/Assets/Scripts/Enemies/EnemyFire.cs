using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour {
    public Transform enemy, shotSpawn;
    private Transform nextPlayerPos;
    public Rigidbody shot;
    private Vector3 Distance;
    private float DistanceFrom;
    public float fireRate = 0.5f, nextFire = 0.0f, velocity;

    void Update() {
        GameObject go = GameObject.Find("Player");
        if (go != null) {
            Vector3 aux = new Vector3(go.transform.position.x, go.transform.position.y, go.transform.position.z + velocity);
            Distance = (enemy.position - aux);
            Distance.y = 0;
            DistanceFrom = Distance.magnitude;
            int posAux = 0;
            if (DistanceFrom < 150) posAux = 25;
            else posAux = 70;
            aux = new Vector3(go.transform.position.x, go.transform.position.y, go.transform.position.z + posAux);
            if (DistanceFrom > 20) enemy.LookAt(aux);
            if (DistanceFrom < 500 && DistanceFrom > 20) {
                if (Time.time > nextFire) {
                    nextFire = Time.time + fireRate;
                    weaponSound();
                    Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                }
            }
            if (enemy.position.z - (aux.z - velocity) < -5) Destroy(gameObject);
        }  
    }

    void weaponSound() {
        if (CompareTag("EnemyGranga")) GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>().PlaySound("GrangaWeapon");
        else if (CompareTag("EnemyTurret")) GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>().PlaySound("TurretWeapon");
        else if (CompareTag("EnemyVenom")) GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>().PlaySound("VenomWeapon");
        else GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>().PlaySound("AsteroidTurretWeapon");
    }
    
}