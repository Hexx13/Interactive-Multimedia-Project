﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int enemyRange = 50;
    public int fromCenterRange = 30;

    
    public List<GameObject> enemyInstances;
    public GameObject[] enemyPrefabs;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        InvokeRepeating("spawnRandomEnemy", 2, 1.5f);
    }


    void spawnRandomEnemy()
    {
        if(enemyInstances.Count <= 10)
        {
            Vector3 coords = generateEnemyCoords();
            instantiateEnemy(coords);
        }
    }

    private float distance(float x1, float y1, float x2, float y2) 
    {
        float distx, disty;
        distx = Mathf.Pow(x2 - x1, 2);
        disty = Mathf.Pow(y2 - y1, 2);
        int result = (int)(Mathf.Sqrt(distx + disty));

        return result;
    }//Method to calculate distance between 2 points using coordinate distance formula

    private void instantiateEnemy(Vector3 coords) 
    {
        //this generates a random number from the enemyPrefabs array for spawning random 
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);

        // creates new instance of a random enemy prefab
        enemyInstances.Insert(enemyInstances.Count, Instantiate(enemyPrefabs[enemyIndex], coords, enemyPrefabs[enemyIndex].transform.rotation));
    }

    private Vector3 generateCoords()
    {
        return new Vector3(Random.Range(-enemyRange, enemyRange), 0, Random.Range(-enemyRange, enemyRange));
    }//creating new set of random coordinates

    private bool isTooCloseToCenter(Vector3 coords)
    {
        if (coords.x > fromCenterRange || coords.z > fromCenterRange || coords.x < -fromCenterRange || coords.z < -fromCenterRange) return false;
        else return true;
    } // method to check if enemy spawn coordinates are too close to the player

    private bool isFirstEnemy (){ 
        if (enemyInstances.Count > 0) return true;
        else return false;
    } // method to check if its first enemy spawn

    private bool isTooCloseToEnemy(Vector3 coords) 
    {
        for (int i = 0; i < enemyInstances.Count;)
        {
            if (distance(coords.x, coords.y, enemyInstances[i].transform.position.x, enemyInstances[i].transform.position.y) < 5)
            {
                return true;
            }
        }
        return false;
    } // method to check if enemy is too close to another enemy

    private bool isCoordGood(Vector3 coords) 
    {
        if (isTooCloseToCenter(coords) == false)
        {
            if (isFirstEnemy() == true) return true;
           
            else if (isTooCloseToEnemy(coords) == false) return true;

            else return false;
        }
        else return false;

        
    }//checks if given coordinates are good for spawning an enemy

    private Vector3 generateEnemyCoords() 
    {
        while (true)
        {
            Vector3 coords = generateCoords();
            if (isCoordGood(coords) == true)
            {
                return coords;
            }
        }
        return Vector3.zero;
    }//returns coordinates for enemy spawn

}
