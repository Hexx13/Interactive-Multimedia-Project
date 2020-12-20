using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private float distanceLimit = 200f;
    private GameManager manager;


    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        deleteObject();
        //checks every frame if object is out of bounds
    }

    private void deleteObject()
    {
        if (transform.position.x > distanceLimit || transform.position.z > distanceLimit)
        {
            manager.delete(gameObject);
        }
        if (transform.position.x < -distanceLimit || transform.position.z < -distanceLimit)
        {
            manager.delete(gameObject);
        }

        if(gameObject.GetComponent<Mass>().getMass() < GameObject.Find("Player").GetComponent<Mass>().getMass() / 2)
        {
            manager.delete(gameObject);
        }
    } // Method that deletes objects after they are out of bounds

}
