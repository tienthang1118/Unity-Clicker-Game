using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_script : MonoBehaviour
{   
    public Transform[] spawnPosition;
    public GameObject[] enemyPrefabs;
    public float spawnTime = 1;
    private float elapsedTime;
    private float baseSpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        baseSpawnTime = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {   
        if(Time_script.timeCountDown > 1){
            spawnTime = baseSpawnTime - (baseSpawnTime / 2) / Time_script.timeLimit * (Time_script.timeLimit - Time_script.timeCountDown);
            elapsedTime += Time.deltaTime;
            if (elapsedTime > spawnTime) 
            {
                int randEnemy = Random.Range(0, enemyPrefabs.Length);
                int randSpawPosition = Random.Range(0, spawnPosition.Length);
                Instantiate(enemyPrefabs[randEnemy], spawnPosition[randSpawPosition].position, transform.rotation);
                elapsedTime = 0;
            }
        }
        
    }
}
