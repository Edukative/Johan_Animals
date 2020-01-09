using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animals;
    public int animalIndex;

    private float spawnRangeX = 20;
    private float spawnPosz = 20;

    private float StartDelay = 2.0f;
    private float SpawnInterval = 1.5f;

    private PlayerController PlayerControllerScript;

    public int animalDestroyedCount;

    public float repeatRateMin = 1;
    public float repeatRateMax= 5;

    void Start()
    {

        
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        Invoke("SpawnRandomAnimal", (Random.Range(repeatRateMin, repeatRateMax)));
    }

    void Update()
    {
        if (PlayerControllerScript.restart)
        {
            Invoke("SpawnRandomAnimal", (Random.Range(repeatRateMin, repeatRateMax)));
            PlayerControllerScript.restart = false;
        }
    }
    void SpawnRandomAnimal()
    {
        if(!PlayerControllerScript.isGameOver)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosz);
            int animalIndex = Random.Range(0, animals.Length);

            GameObject animal = Instantiate(animals[animalIndex], spawnPos,
            animals[animalIndex].transform.rotation);

            Flyforward animScript = animal.GetComponent<Flyforward>();
            animScript.speed = animScript.speed + (float)animalDestroyedCount;


            float randomDelay = Random.Range(repeatRateMin, repeatRateMax);
            Debug.Log("That was Random!" + randomDelay);
            Invoke("SpawnRandomAnimal", randomDelay);
        }

        
    }
}

