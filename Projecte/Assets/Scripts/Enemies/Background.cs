using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {
    public GameObject hazard, boundary;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait, startWait, waveWait;

    void Start () {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves () {
        yield return new WaitForSeconds (startWait);
        while (true) {
            
            for (int i = 0; i < hazardCount/4; i++) {
                Vector3 spawnPosition = new Vector3 (Random.Range (-100, -10), Random.Range (-50, 50), boundary.transform.position.z + spawnValues.z);
                Instantiate (hazard, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds (spawnWait);
            }
            for (int i = 0; i < hazardCount/4; i++) {
                Vector3 spawnPosition = new Vector3 (Random.Range (15, 100), Random.Range (-50, 50), boundary.transform.position.z + spawnValues.z);
                Instantiate (hazard, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds (spawnWait);
            }
            for (int i = 0; i < hazardCount/8; i++) {
                Vector3 spawnPosition = new Vector3 (Random.Range (-10, 10), Random.Range (15, 50), boundary.transform.position.z + spawnValues.z);
                Instantiate (hazard, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds (spawnWait);
            }
            for (int i = 0; i < hazardCount/8; i++) {
                Vector3 spawnPosition = new Vector3 (Random.Range (-10, 10), Random.Range (-15, -50), boundary.transform.position.z + spawnValues.z);
                Instantiate (hazard, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds (spawnWait);
            }
            
            yield return new WaitForSeconds (waveWait);
        }
    }
    
}