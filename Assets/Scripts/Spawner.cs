using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    public GameObject ObjectToSpawn;
    public int totalToSpawn = 40;
    public float spawnInterval = 3f;
    private int numSpawned = 0;
    public GameObject player;
    public Terrain terrain;

    void Start () {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn() {
        while (numSpawned < totalToSpawn) {
            Quaternion randomRotation =
                Quaternion.AngleAxis(Random.Range(0,360), Vector3.up);
            Vector3 spawnLoc = new Vector3(0, 0, 0);
            while(terrain.SampleHeight(spawnLoc) >= 10 || spawnLoc.y == 0) {
                spawnLoc =new Vector3(Random.Range(200f, 800f),
                            terrain.SampleHeight(spawnLoc) + 5.0f,
                            Random.Range(200f, 800f));
            }
            Instantiate(ObjectToSpawn,
                    spawnLoc, randomRotation);
            numSpawned++;
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
