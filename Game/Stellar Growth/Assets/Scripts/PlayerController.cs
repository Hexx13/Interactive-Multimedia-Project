using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Mass playerMass;
    private GameManager manager;
    public int growthFactor = 5;

    // Start is called before the first frame update
    void Start()
    {
        playerMass = GameObject.Find("Player").GetComponent<Mass>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Mass>().getMass() < playerMass.getMass()*1.3f)
        {
             if (collision.gameObject.CompareTag("Asteroid"))
            {
                playerMass.setMass(playerMass.getMass() + (collision.gameObject.GetComponent<Mass>().getMass()/growthFactor));
                manager.delete(collision.gameObject);
                Vector3 camPos = GameObject.Find("Main Camera").transform.position;
                GameObject.Find("Main Camera").transform.position = new Vector3 (0, camPos.y+2, camPos.z - 1);
                
            }

            else if (collision.gameObject.CompareTag("Planet"))
            {
                playerMass.setMass(playerMass.getMass() + (collision.gameObject.GetComponent<Mass>().getMass()/growthFactor));
                manager.delete(collision.gameObject);
                Vector3 camPos = GameObject.Find("Main Camera").transform.position;
                GameObject.Find("Main Camera").transform.position = new Vector3 (0, camPos.y+2, camPos.z - 1);
            }
        }
        else
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().gameOver =true;
        }
       
    }
}
