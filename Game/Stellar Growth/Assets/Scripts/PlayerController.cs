using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public bool gameOver = false;
    private Mass playerMass;
    private Mass enemyMass;
    

    // Start is called before the first frame update
    void Start()
    {
        playerMass = GameObject.Find("Player").GetComponent<Mass>();
        enemyMass = GameObject.Find("Asteroid").GetComponent<Mass>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerMass.setMass(playerMass.objectMass + enemyMass.objectMass);
            Destroy(collision.gameObject);
        }

        else if (collision.gameObject.CompareTag("Enemy"))
        {

        }
    }
}
