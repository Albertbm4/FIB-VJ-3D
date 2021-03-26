using UnityEngine;
using System.Collections;

public class Stars : MonoBehaviour {
	private Transform tx;
	private ParticleSystem.Particle[] points;
	public int starsMax = 100;
	public float starSize = 1, starDistance = 10, starClipDistance = 1;
	private float starDistanceSqr, starClipDistanceSqr;

	void Start () {
		tx = transform;
		starDistanceSqr = starDistance * starDistance;
		starClipDistanceSqr = starClipDistance * starClipDistance;
		
		points = new ParticleSystem.Particle[starsMax];

		for (int i = 0; i < starsMax; i++) {
			points[i].position = Random.insideUnitSphere * starDistance + tx.position;
			points[i].startColor = new Color(1, 1, 1, 1);
			points[i].startSize = starSize;
		}
	}

	void Update () {

		for (int i = 0; i < starsMax; i++) {
			if ((points[i].position - tx.position).sqrMagnitude > starDistanceSqr) {
				points[i].position = Random.insideUnitSphere.normalized * starDistance + tx.position;
			}
			if ((points[i].position - tx.position).sqrMagnitude <= starClipDistanceSqr) {
				float percent = (points[i].position - tx.position).sqrMagnitude / starClipDistanceSqr;
				points[i].startColor = new Color(1,1,1, percent);
				points[i].startSize = percent * starSize;
			}
		}
		GetComponent<ParticleSystem>().SetParticles(points, points.Length);
	}

}
