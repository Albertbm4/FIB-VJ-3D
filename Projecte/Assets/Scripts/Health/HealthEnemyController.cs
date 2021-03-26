using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemyController : MonoBehaviour {
    public GameObject explosion, specialExplosion;
    public int health = 5;
    private bool iAmHit = false;

    void Update() {
        GameObject go = GameObject.Find("Player");
        if (go != null) { 
            if (gameObject.transform.position.z - go.transform.position.z < -5) Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("PlayerFire")) {
            soundAndDestroy(1, explosion, other);
            if (isEnemy()) {
                if (!iAmHit) {
                    FindObjectOfType<PlayerMovement>().Hit();
                    iAmHit = true;
                }
            }
        }
        else if (other.CompareTag("SpecialShot")) {
            soundAndDestroy(2, specialExplosion, other);
            if (isEnemy()) FindObjectOfType<PlayerMovement>().Hit();
        }
        else if (other.CompareTag("Explotion")) {
            soundAndDestroy(1, explosion, other);
        }
        else if (other.CompareTag("EnemyFire") || other.CompareTag("Venom")) {
            Destroy(other.gameObject);
        }
        else if (isEnemy(other) || other.CompareTag("Asteroid")) {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Rock")) {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }

    }  

    private void soundAndDestroy(int damage, GameObject explo, Collider other) {
        health -= damage;
        Destroy(other.gameObject);

        if (health <= 0) {
            explosionSound();
            Instantiate(explo, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    bool isEnemy(Collider other) {
        return (other.CompareTag("EnemyGranga") || other.CompareTag("EnemyTurret") || other.CompareTag("EnemyVenom") || other.CompareTag("EnemyLaserCannon"));
    }

    bool isEnemy() {
        return (CompareTag("EnemyGranga") || CompareTag("EnemyTurret") || CompareTag("EnemyVenom") || CompareTag("EnemyLaserCannon"));
    }

    void explosionSound() {
        if (CompareTag("EnemyGranga")) GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>().PlaySound("GrangaExplosion");
        else if (CompareTag("EnemyTurret")) GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>().PlaySound("TurretExplosion");
        else if (CompareTag("EnemyVenom")) GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>().PlaySound("VenomExplosion");
        else if (CompareTag("Asteroid")) GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>().PlaySound("AsteroidExplosion");
        else GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>().PlaySound("AsteroidTurretExplosion");
    }

}
