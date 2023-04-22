using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject Floor;
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float spawnRate;
    [SerializeField]
    private int populationSize;
    [SerializeField]
    private int populationGrowth;
    [SerializeField]
    private int populationGrowthRateInCycles;

    private float lastTimeSpawned;

    private int populationCycles;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastTimeSpawned + spawnRate) {
            Spawn();
        }
    }

    private Vector3 CalculateSpawnPos() {
        float x = Random.Range(-Floor.transform.localScale.x - 1, Floor.transform.localScale.x - 1);
        float y = 1;
        float z = Random.Range(-Floor.transform.localScale.z - 1, Floor.transform.localScale.z - 1);
        return new Vector3(x,y,z);
    }

    private void Spawn() {
        for(int i = 0; i < populationSize; i++) {
                Instantiate(enemyPrefab, CalculateSpawnPos(), new Quaternion());
        }
        populationCycles++;
        lastTimeSpawned = Time.time;
            
        if (populationGrowthRateInCycles != 0 && populationCycles % populationGrowthRateInCycles == 0) {
            populationSize += populationGrowth;
        }
    }
}
