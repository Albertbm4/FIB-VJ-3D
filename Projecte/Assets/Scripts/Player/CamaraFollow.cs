using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollow : MonoBehaviour {
    public Transform target;
    public Vector3 offset = Vector3.zero, velocity = Vector3.zero;
    public Vector2 limits = new Vector2(5, 3);
    public float smoothTime;

    void Update() {
        if (!Application.isPlaying) transform.localPosition = offset;
        if (target != null) FollowTarget(target);
    }

    void LateUpdate() {
        Vector3 localPos = transform.localPosition;
        transform.localPosition = new Vector3(Mathf.Clamp(localPos.x, -limits.x, limits.x), Mathf.Clamp(localPos.y, -limits.y, limits.y), localPos.z);
    }

    public void FollowTarget(Transform t) {
        Vector3 localPos = transform.localPosition;
        Vector3 targetLocalPos = t.transform.localPosition;
        transform.localPosition = Vector3.SmoothDamp(localPos, new Vector3(targetLocalPos.x + offset.x, targetLocalPos.y + offset.y, localPos.z), ref velocity, smoothTime);
    }
    
}
