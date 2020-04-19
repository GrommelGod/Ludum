using Assets.Scripts.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{

    [SerializeField]
    private float secondsBetweenSpawn;

    private float timeElapsedSinceLastCreation;

    [SerializeField]
    private GameObject[] zones;

    [SerializeField]
    private GameObject[] possiblePrefabs;

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
            GameObject zone = zones[UnityEngine.Random.Range(0, zones.Length)];

            var typesPossible = Enum.GetValues(typeof(EnemyType)).Cast<EnemyType>().ToArray();
            var chosenType = typesPossible[UnityEngine.Random.Range(0, typesPossible.Length)];

            var enemyPrefab = possiblePrefabs.Where(p => p.name == chosenType.ToString()).FirstOrDefault();

            if (enemyPrefab != null)
            {
                GameObject.Instantiate(enemyPrefab, zone.transform.position, Quaternion.identity);
            }

            timeElapsedSinceLastCreation = 0;
        }
    }
}
