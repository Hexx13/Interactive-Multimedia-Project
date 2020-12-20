using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class howPlay : MonoBehaviour
{

    public TextMeshProUGUI howPlayText;
    public Image logo;
    public GameObject startButton, howPlayButton, backButton, repoButton;
    private ButtonPop soundMachine;
    
    
    // Start is called before the first frame update
    void Start()
    {
        soundMachine = gameObject.GetComponent<ButtonPop>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void displayHowPlayText()
    {
        soundMachine.playPop();
        
        howPlayText.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
        logo.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        howPlayButton.gameObject.SetActive(false);
        repoButton.gameObject.SetActive(false);
    }
    //shows the how to play screen
    public void hideHowPlayText()
    {
        soundMachine.playPop();
        
        howPlayText.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
        logo.gameObject.SetActive(true);
        startButton.gameObject.SetActive(true);
        howPlayButton.gameObject.SetActive(true);
        repoButton.gameObject.SetActive(true);
    }
    //hides how to play screen
}
