using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float distanceLimit = 100f;
    private PlayerController controller;
    private SpawnManager manager;


    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Player").GetComponent<PlayerController>();
        manager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        

        
        


        if (transform.position.x > distanceLimit || transform.position.z > distanceLimit) 
        {
            manager.delete(gameObject);
            
        }

        
        if (transform.position.x < -distanceLimit || transform.position.z < -distanceLimit) 
        {
            manager.delete(gameObject);
        }
    }

    public int getIndex()
    {
        return int.Parse(gameObject.name);
    }

}
