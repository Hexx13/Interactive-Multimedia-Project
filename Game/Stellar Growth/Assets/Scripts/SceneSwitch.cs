using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goLevel1()
    {
        
        SceneManager.LoadScene("Stage 1");
    }

    public void goMainMenu()
    {
        
        SceneManager.LoadScene("Main Menu");
    }
}
