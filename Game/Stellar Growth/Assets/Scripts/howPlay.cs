using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class howPlay : MonoBehaviour
{

    public TextMeshProUGUI howPlayText;
    public Image logo;
    public Button startButton, howPlayButton, backButton;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void displayHowPlayText()
    {
        howPlayText.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
        logo.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        howPlayButton.gameObject.SetActive(false);

    }

    public void hideHowPlayText()
    {
        howPlayText.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
        logo.gameObject.SetActive(true);
        startButton.gameObject.SetActive(true);
        howPlayButton.gameObject.SetActive(true);
    }
}
