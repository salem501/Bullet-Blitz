using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private PlayerController player;
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
        player = FindAnyObjectByType<PlayerController>();
        setPopulationSize();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastTimeSpawned + spawnRate) {
            Spawn();
        }
    }

    private void setPopulationSize() {
        populationSize = 8 + 2 * player.level;
    }

    private Vector3 CalculateSpawnPos() {
        float x = Random.Range(-500,500);
        float y = -0.5f;
        float z = Random.Range(-500,500);
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
