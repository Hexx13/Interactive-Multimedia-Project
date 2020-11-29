using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("GameManager").GetComponent<GameManager>().gameOver == false)
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0f,Input.GetAxis("Vertical") * Time.deltaTime * speed);
    }
}
