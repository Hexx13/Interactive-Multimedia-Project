using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed = 10;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        //changes speed
        if(player.GetComponent<Mass>().getMass() > 3){
            speed = player.GetComponent<Mass>().getMass() * 3.15f;
        }
        else if (player.GetComponent<Mass>().getMass() > 5){
            speed = player.GetComponent<Mass>().getMass() * 2.12f;
        }
        
        //checks if game is over wether to move or not
        if(GameObject.Find("GameManager").GetComponent<GameManager>().gameOver == false)
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0f,Input.GetAxis("Vertical") * Time.deltaTime * speed);
    }
}
