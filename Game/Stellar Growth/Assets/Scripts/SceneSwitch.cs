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


    public void openRepository(){
        Application.OpenURL("https://github.com/Hexx13/Interactive-Multimedia-Project");
    }
    public void goLevel3(){
        SceneManager.LoadScene("Stage 3");
    }
    //sends you to level 2

    public void goLevel2(){
        SceneManager.LoadScene("Stage 2");
    }
    //sends you to level 2

        public void goLevel1()
    {
        
        SceneManager.LoadScene("Stage 1");
    }
    //sends you to level 1
    public void goMainMenu()
    {
        
        SceneManager.LoadScene("Main Menu");
    }
    //sends you to main menu
}
