using UnityEngine;
using System.Collections;

public class PlayerShot : MonoBehaviour {
    public GameObject shotBasic, shotSpecial;
    public Transform shotSpawn;
    private float nextFireBasic, nextFireSpecial;
    public float fireRate;
    
    void Update () {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFireBasic) {
            nextFireBasic = Time.time + fireRate;
            GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>().PlaySound("PlayerWeapon");
            Instantiate(shotBasic, shotSpawn.position + new Vector3(-0.75f, -0.5f, 0), shotSpawn.rotation);
            Instantiate(shotBasic, shotSpawn.position + new Vector3(0.75f, -0.5f, 0), shotSpawn.rotation);
        }
        else if (Input.GetKeyDown("c") && Time.time > nextFireSpecial) {
            nextFireSpecial = Time.time + fireRate * 4;
            GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>().PlaySound("PlayerWeaponSpecial");
            Instantiate(shotSpecial, shotSpawn.position + new Vector3(0, -0.5f, 0), shotSpawn.rotation);
        }
    }

}