using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //private PlayerController playerControllerScript;

    private float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        //playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0f,Input.GetAxis("Vertical") * Time.deltaTime * speed);
    }
}
