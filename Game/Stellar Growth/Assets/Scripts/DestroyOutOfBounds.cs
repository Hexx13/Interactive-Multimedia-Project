using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : SpawnManager
{
    public float distanceLimit = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > distanceLimit || transform.position.z > distanceLimit) 
        {
            Destroy(gameObject);
            enemyInstances.RemoveAt(enemyInstances.IndexOf(gameObject));
        }


        if (transform.position.x < -distanceLimit || transform.position.z < -distanceLimit) 
        {
            Destroy(gameObject);
            enemyInstances.RemoveAt(enemyInstances.IndexOf(gameObject));
        }
    }
}
