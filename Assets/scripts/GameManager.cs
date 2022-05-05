using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    public GameObject carPrefab;
    public Transform[] carSpawnPoints;

    void Start()
    {
        InvokeRepeating("SpawnCar", 1, 1);
        //spawn cars starting at x, every y
    }

    // Update is called once per frame
    void Update()
    {


        //if (Input.GetKeyDown(KeyCode.Space))
        //{

        //    SceneManager.LoadScene("frogger-game");
        //}
    }



    //if (Input.GetKeyDown(KeyCode.Space))
    //{
    //    SpawnCar();

    //}


    void SpawnCar()
    {
        int index = Random.Range(0, carSpawnPoints.Length);
        Vector3 spawnPos = carSpawnPoints[index].position;

        GameObject car = Instantiate(carPrefab, spawnPos, Quaternion.identity);

        car.GetComponent<SpriteRenderer>().color = new Color
            (Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

        int dirModifier = 1;
        if (index > 2)
        {
            dirModifier = -1;
            car.GetComponent<SpriteRenderer>().flipX = true;
        }


        car.GetComponent<CarMovement>().speed = Random.Range(3.0f, 6.0f);

        car.GetComponent<CarMovement>().speed *= dirModifier;

    }

}
