using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mass : MonoBehaviour
{

    public int objectMass = 1;
    private Vector3 size;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        size = new Vector3(objectMass, objectMass, objectMass);
        transform.localScale = size;
    }


    public void setMass(int mass)
    {
        this.objectMass = mass;
    }

    public int getMass()
    {
        return this.objectMass;
    }

}
