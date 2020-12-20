using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mass : MonoBehaviour
{

    public float objectMass = 1;
    private Vector3 size;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //vector for setting the size
        size = new Vector3(objectMass, objectMass, objectMass);
        //setting the size of the object of to size
        transform.localScale = size;
    }


    public void setMass(float mass)
    {
        this.objectMass = mass;
    }
//setter method for mass
    public float getMass()
    {
        return this.objectMass;
    }
// getter method for mass
}
