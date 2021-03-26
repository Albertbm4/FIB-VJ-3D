using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayerController : MonoBehaviour {
    public HealthBar healthBar;
    public GameObject damage, explosion, godSphere;
    public int health = 30;
    [HideInInspector]
    public bool godMode = false, isRolling = false;

    void Start() {
        if (gameObject.CompareTag("Player")) healthBar.SetMaxHealth(health);
    }

    void Update() {
        if (Input.GetKeyDown("g")) godMode = !godMode;
        if (godMode) {
            godSphere.SetActive(true);
            healthBar.SetGodHealth(true);
        }
        else {
            godSphere.SetActive(false);
            healthBar.SetGodHealth(false);
        }   
        isRolling = GetComponent<PlayerMovement>().barrelRoll;
    }

    void OnTriggerEnter (Collider other) {
        if (!isRolling) {
            if (other.CompareTag("EnemyFire")) {
                if (!godMode) --health; 
                UpdateDamageAndSounds(other);
            }
            else if (other.CompareTag("CannonFire")) {
                if (!godMode) health -= 5; 
                UpdateDamageAndSounds(other);
            }
            else if (isEnemy(other)) {
                if (!godMode) health -= 3;
                Instantiate(explosion, other.transform.position, other.transform.rotation);
                UpdateDamageAndSounds(other);
            }
            else if (other.CompareTag("Rock") || other.CompareTag("Asteroid")) {
                if (!godMode) health -= 5;
                UpdateDamageAndSounds(other);
            }
            else if (other.CompareTag("Venom")) {
                if (!godMode) {
                    poisoned();
                }
            }
        }
    }

    bool isEnemy(Collider other) {
        return other.CompareTag("EnemyGranga") || other.CompareTag("EnemyTurret") || other.CompareTag("EnemyVenom") || other.CompareTag("EnemyLaserCannon");
    }

    void UpdateDamageAndSounds(Collider other) {
        Destroy(other.gameObject);

        if (!godMode) {
            healthBar.SetHealth(health);
            damage.SetActive(true);
            GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>().PlaySound("PlayerDamage");
            Invoke("TakeDamage", 0.2f);
        }
            
        if (health <= 0) {
            GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>().PlaySound("PlayerExplosion");
            Destroy(gameObject);
            FindObjectOfType<EventMenus>().Pause();
        }
    }

    void TakeDamage() {
        damage.SetActive(false);
        damage.GetComponentInChildren<Image>().color = new Color(0.5f, 0, 0, 0.4f);
    }

    void dmgVenom() {
        health -= 1;
        healthBar.SetHealth(health);
        damage.GetComponentInChildren<Image>().color = new Color(0, 0.5f, 0, 0.4f);
        damage.SetActive(true);
        Invoke("TakeDamage", 0.2f);
        if (health <= 0) {
            GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>().PlaySound("PlayerExplosion");
            Destroy(gameObject);
            FindObjectOfType<EventMenus>().Pause();
        }
    }

    void finishVenom() {
        GameObject.FindWithTag("Poison").GetComponentInChildren<Image>().enabled = false;
    }

    void poisoned() {
        GameObject.FindWithTag("Poison").GetComponentInChildren<Image>().enabled = true;
        dmgVenom();
        Invoke("dmgVenom", 1f);
        Invoke("finishVenom", 1.2f);
    }

}
