using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class howPlay : MonoBehaviour
{

    public TextMeshProUGUI howPlayText;
    public Image logo;
    public GameObject startButton, howPlayButton, backButton;
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
    IEnumerator wait(){
        yield return new WaitForSeconds(3);
    }
    public void displayHowPlayText()
    {
        soundMachine.playPop();
        howPlayText.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
        logo.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        howPlayButton.gameObject.SetActive(false);

    }

    public void hideHowPlayText()
    {
        soundMachine.playPop();
        howPlayText.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
        logo.gameObject.SetActive(true);
        startButton.gameObject.SetActive(true);
        howPlayButton.gameObject.SetActive(true);
    }
}
