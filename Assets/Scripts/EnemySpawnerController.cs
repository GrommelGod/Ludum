using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{

    [SerializeField]
    private float secondsBetweenSpawn;

    private float timeElapsedSinceLastCreation;

    [SerializeField]
    private GameObject[] zones;

    [SerializeField]
    private GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsedSinceLastCreation += Time.deltaTime;

        if (timeElapsedSinceLastCreation > secondsBetweenSpawn)
        {
            GameObject zone = zones[Random.Range(0, zones.Length)];
            GameObject.Instantiate(enemyPrefab, zone.transform.position, Quaternion.identity);
            timeElapsedSinceLastCreation = 0;
        }
    }
}
