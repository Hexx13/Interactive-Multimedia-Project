using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float distanceLimit = 100f;
    private PlayerController controller;
    private GameManager manager;


    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Player").GetComponent<PlayerController>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        deleteObject();
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
    }

}
