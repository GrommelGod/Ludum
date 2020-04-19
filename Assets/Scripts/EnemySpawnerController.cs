using Assets.Scripts.Enums;
using Assets.Scripts.Models;
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

    [SerializeField]
    private AudioSource GrandmaDeathSound;

    [SerializeField]
    private AudioSource MaleDeathSound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float points = GameStats.Instance.points;
        float level = points / 15;

        float probaJogger = level * 0.15f;
        float timeBetweenEnemies = secondsBetweenSpawn - level;


        if (timeBetweenEnemies < 2)
        {
            timeBetweenEnemies = 2;
        }


        timeElapsedSinceLastCreation += Time.deltaTime;


        if (timeElapsedSinceLastCreation > timeBetweenEnemies)
        {
            int numEnemies = 1;
            float randomNumber = UnityEngine.Random.value;

            if (points > 30)
            {
                if (randomNumber < 0.5f)
                {
                    numEnemies = 2;
                }
            }

            if (points > 150)
            {
                if (randomNumber < 0.5f)
                {
                    numEnemies = 3;
                }
            }

            var typesToCreate = new List<EnemyType>();

            while(typesToCreate.Count < numEnemies)
            {
                EnemyType chosenType = EnemyType.Hipster;

                if (typesToCreate.Count > 0)
                {
                    var hasJogger = typesToCreate.Count(t => t == EnemyType.Jogger) > 0;
                    if (hasJogger)
                    {
                        float rand2 = UnityEngine.Random.value;
                        if (rand2 < .5f)
                        {
                            typesToCreate.Add(EnemyType.Hipster);
                        }
                        else
                        {
                            typesToCreate.Add(EnemyType.Grandma);

                        }
                        continue;
                    }
                }

                if (randomNumber < probaJogger)
                {
                    chosenType = EnemyType.Jogger;
                }
                else
                {
                    float rest = 1 - randomNumber;
                    if (randomNumber < rest / 2)
                    {
                        chosenType = EnemyType.Grandma;
                    }
                }

                typesToCreate.Add(chosenType);
            }

            foreach (var chosenType in typesToCreate)
            {
                GameObject zone = zones[UnityEngine.Random.Range(0, zones.Length)];

                var enemyPrefab = possiblePrefabs.Where(p => p.name == chosenType.ToString()).FirstOrDefault();

                if (enemyPrefab != null)
                {
                    GameObject.Instantiate(enemyPrefab, zone.transform.position, Quaternion.identity);
                    enemyPrefab.GetComponent<EnemyController>().deathSound = chosenType == EnemyType.Grandma ? GrandmaDeathSound : MaleDeathSound;
                }
            }


            timeElapsedSinceLastCreation = 0;
        }
    }
}
