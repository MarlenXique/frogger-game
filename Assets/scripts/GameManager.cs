using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    public GameObject carPrefab;
    public Transform[] carSpawnPoints;

    void Start()
    {
        SpawnCar();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnCar();

        }
    }

    void SpawnCar()
    {
        int index = Random.Range(0, carSpawnPoints.Length);
        Vector3 spawnPos = carSpawnPoints[index].position;

        GameObject car = Instantiate(carPrefab, spawnPos, Quaternion.identity);

        int dirModifier = 1;
        if (index > 2)
        {
            dirModifier = -1;
        }


        car.GetComponent<CarMovement>().speed = Random.Range(3.0f, 6.0f);

        car.GetComponent<CarMovement>().speed *= dirModifier;

    }

}
