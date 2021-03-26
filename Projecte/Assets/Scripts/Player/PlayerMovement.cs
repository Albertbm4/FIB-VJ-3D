using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMovement : MonoBehaviour {
    private Transform playerModel;
    public ParticleSystem barrel;
    public TrailRenderer boostLeft, boostRight;
    public EventMenus winMenu;
    public Text countText;
    public float xySpeed = 18;
    public int incremental = 0;
    private int count = 0;
    [HideInInspector]
    public bool barrelRoll = false, iAmBoosting = false;
    
    void Start() {
        playerModel = transform.GetChild(0);
    }

    void Update() {
        float movementHorizontal = Input.GetAxis("Horizontal");
        float movementVertical = Input.GetAxis("Vertical");
        LocalMove(movementHorizontal, movementVertical, xySpeed);
        HorizontalLean(playerModel, movementHorizontal, 40, .1f);
        VerticalLean(playerModel, movementVertical, 20, .1f);

        if (!barrelRoll) {
            if (Input.GetKeyDown("b")) barrelRoll = true;
        }
        else {
            doBarrelRoll(playerModel);
            barrel.Play();
        }

        if (!iAmBoosting) {
            if (Input.GetKeyDown("v")) {
                iAmBoosting = true;
                GameObject.FindWithTag("Cinemachine").GetComponent<CinemachineDollyCart>().m_Speed *= 2f;
                boostLeft.emitting = boostRight.emitting = true;
                Invoke("stopBoosting", 1f);
            }
        }
    }

    void doBarrelRoll(Transform target) {
        Vector3 targetEulerAngels = target.localEulerAngles;
        incremental += 20;
        target.localEulerAngles = new Vector3(targetEulerAngels.x, targetEulerAngels.y, incremental);
        if (incremental >= 360) {
            incremental = 0;
            barrelRoll = false;
        }
    }

    void LocalMove(float x, float y, float speed) {
        transform.localPosition += new Vector3(x, y, 0) * speed * Time.deltaTime;

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    void HorizontalLean(Transform target, float axis, float leanLimit, float lerpTime) {
        Vector3 angles = target.localEulerAngles;
        target.localEulerAngles = new Vector3(angles.x, angles.y, Mathf.LerpAngle(angles.z, -axis * leanLimit, lerpTime));
    }

    void VerticalLean(Transform target, float axis, float leanLimit, float lerpTime) {
        Vector3 angles = target.localEulerAngles;
        target.localEulerAngles = new Vector3(Mathf.LerpAngle(angles.x, -axis * leanLimit, lerpTime), angles.y, angles.z);
    }

    public void Hit() {
        ++count;
        countText.text = count.ToString();
    }

    private void stopBoosting() {
        boostLeft.emitting = boostRight.emitting = false;
        iAmBoosting = false;
        GameObject.FindWithTag("Cinemachine").GetComponent<CinemachineDollyCart>().m_Speed /= 2f;
    }

    void OnTriggerEnter (Collider other) {
        if (other.CompareTag("Final")) {
            GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>().PlaySound("Victoria");
            FindObjectOfType<EventMenus>().Win();
        }
    }

}
