using UnityEngine;
using System.Collections;

public class EnemyWaves : MonoBehaviour {
    public GameObject enemy1, enemy2, boundary;
    private GameObject hazard;
    public int numEnemies, posSpawnZ;
    public float enemiesTime, firstWave, wavesTime, zFinal;

    void Start () {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves () {
        yield return new WaitForSeconds(firstWave);
        while (true) {
            for (int i = 0; i < numEnemies; i++) {
                if (boundary.transform.position.z >= 450 && boundary.transform.position.z <= 800) hazard = enemy1;
                else if (boundary.transform.position.z >= 900 && boundary.transform.position.z <= 1400) hazard = enemy2;
                else {
                    if (Random.Range(0,2) >= 1) hazard = enemy1;
                    else hazard = enemy2;
                }

                Vector3 spawnPosition = new Vector3(boundary.transform.position.x + Random.Range(-20, 20), boundary.transform.position.y + Random.Range(-10, 10), boundary.transform.position.z + posSpawnZ);
                
                if(spawnPosition.z <= zFinal) {
                    Instantiate(hazard, spawnPosition, Quaternion.identity);
                }
                yield return new WaitForSeconds(enemiesTime);
            }
            yield return new WaitForSeconds(wavesTime);
        }
    }

}