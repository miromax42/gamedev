using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float nextTimeToSpawn;
    public float spawnRate;

    public float spawnRange;

    public GameObject objToSpawn;
  
    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextTimeToSpawn)
        {
            nextTimeToSpawn = Time.time + 1f / spawnRate;
            Vector3 position2spawn = transform.position + new Vector3(Random.Range(-spawnRange, spawnRange), Random.Range(-spawnRange, spawnRange), Random.Range(-spawnRange, spawnRange));
            Instantiate(objToSpawn, position2spawn, transform.rotation);
        }
        
    }
}
