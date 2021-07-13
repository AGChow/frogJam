using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //obstacles
    public GameObject Car1;
    public GameObject Car2;
    public GameObject Car3;
    public GameObject Bus;
    public GameObject Truck;

    public float TrafficMaxSpeed = 5;

    public GameObject[] Vehicles;

    //platforms
    public GameObject log;
    public GameObject longLog;

    public GameObject pipe;
    public GameObject trashPile;

    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public Transform spawnPoint4;
    public Transform spawnPoint5;
    public Transform spawnPoint6;
    public Transform spawnPoint7;
    public Transform spawnPoint8;

    public bool TrafficOn;
    public bool LogsOn;
    public bool inSecondLevel;



    public float SpawnSpeed = 2f;
    public float SpawnSpeed2 = 2f;

    public float maxSpawnSpeed = 5;
    public float maxSpawnSpeed2 = 4;


    private void Start()
    {
        StartCoroutine(SecondLevel());
        StartCoroutine(SpawnCar());
        StartCoroutine(SpawnCar2());
        StartCoroutine(SpawnPlatforms());


        for (int i = 0; i < Vehicles.Length; i++)
        {
            Vehicles[i].GetComponent<CarMove>().maxSpeed = TrafficMaxSpeed;
        }
    }

    private void Update()
    {
        SpawnSpeed = Random.Range(2, maxSpawnSpeed);
        SpawnSpeed2 = Random.Range(2, maxSpawnSpeed2);
    }


    public  IEnumerator SpawnCar()
    {
        while (TrafficOn == true)
        {
        yield return new WaitForSeconds(SpawnSpeed);
        CarSpawn();
        }

    }

    public IEnumerator SpawnCar2()
    {
        while (TrafficOn == true)
        {
            yield return new WaitForSeconds(SpawnSpeed2);
            CarSpawn2();
        }
    }

    public IEnumerator SecondLevel()
    {
        while(inSecondLevel == true)
        {
            yield return new WaitForSeconds(SpawnSpeed);
            Instantiate(Car1, spawnPoint2);
            Instantiate(Car1, spawnPoint3);
        }
    }
    public IEnumerator SpawnPlatforms()
        {
            while(LogsOn == true)
            {
                yield return new WaitForSeconds(SpawnSpeed);
                {
                    LogSpawn1();
                }
            }
        }

    public void CarSpawn()
    {
        int randomIndex = Random.Range(0, Vehicles.Length);
        int randomIndex2 = Random.Range(0, Vehicles.Length);


        GameObject instantiatedObject = Instantiate(Vehicles[randomIndex], spawnPoint1) as GameObject;

        GameObject instantiatedObject4 = Instantiate(Vehicles[randomIndex2], spawnPoint4) as GameObject;
    }

    public void CarSpawn2()
    {
        int randomIndex3 = Random.Range(0, Vehicles.Length);
        int randomIndex4 = Random.Range(0, Vehicles.Length);


        GameObject instantiatedObject2 = Instantiate(Vehicles[randomIndex3], spawnPoint2) as GameObject;

        GameObject instantiatedObject3 = Instantiate(Vehicles[randomIndex4], spawnPoint3) as GameObject;


    }



    public void LogSpawn1()
    {
        Instantiate(log, spawnPoint5);
        Instantiate(log, spawnPoint6);
        Instantiate(log, spawnPoint7);
        Instantiate(log, spawnPoint8);
    }




}
