using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public int enemyRange = 50;
    private float fromCenterRange;
    public int distanceFromEnemy = 10;
    public int maxEnemy = 20;
    private int massScore;
    public bool gameOver;
    public bool winGame;
    public int winAmount;
    

    GameObject player;
    public TextMeshProUGUI scoreText, gameOverText;    
    public Button restartButton, mainMenuButton, nextlvltbutton;
    public List<GameObject> enemyInstances;
    public GameObject[] enemyPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        gameOver = false;
        winGame = false;
    }

    // Update is called once per frame
    void Update()
    {

        fromCenterRange = player.GetComponent<Mass>().getMass() * 20.0f;

        if(GameObject.Find("Player").GetComponent<Mass>().getMass() > winAmount)
        {   winGame=true;
            gameOver = true;
            endGameScreen();
            gameOverText.text = "You Win!";
        }

        updateMassScore();
        if(gameOver == false)
        {
            InvokeRepeating("spawnRandomEnemy", 2, 1.5f);
        }
        else if(gameOver)
        {
            endGameScreen();
        }
    }


    void spawnRandomEnemy()
    {
        if(enemyInstances.Count < maxEnemy)
        {
            Vector3 coords = generateEnemyCoords();
            instantiateEnemy(coords);
        }
    }
    // final method for spawning enemies checks if max enemies have spawned and sets spawn coordinates
    private void instantiateEnemy(Vector3 coords) 
    {
        //this generates a random number from the enemyPrefabs array for spawning random 
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);

        // creates new instance of a random enemy prefab
        enemyInstances.Insert(enemyInstances.Count, Instantiate(enemyPrefabs[enemyIndex], coords, enemyPrefabs[enemyIndex].transform.rotation));
        instantiateMass(enemyInstances[enemyInstances.Count-1]);
        
    }
    //method that decides which enemy prefab is used, instantiates enemy and adds it to the list, and sets the random mass
    private Vector3 generateCoords()
    {
        return new Vector3(Random.Range(-enemyRange, enemyRange), 0, Random.Range(-enemyRange, enemyRange));
    }
    //creating new set of random coordinates
    private bool isTooCloseToCenter(Vector3 coords)
    {
        if (coords.x > fromCenterRange || coords.z > fromCenterRange || coords.x < -fromCenterRange || coords.z < -fromCenterRange) return false;
        else return true;
    } 
    // method to check if enemy spawn coordinates are too close to the player
    private bool isFirstEnemy (){ 
        if (enemyInstances.Count > 0) return false;
        else return true;
    } 
    // method to check if its first enemy spawn
    private bool isTooCloseToEnemy(Vector3 coords) 
    {
        for (int i = 0; i < enemyInstances.Count;i++)
        {
            if (Vector3.Distance(coords, enemyInstances[i].transform.position) < distanceFromEnemy)
                return true;  
        }
        return false;
    } 
    // method to check if enemy is too close to another enemy
    private bool isCoordGood(Vector3 coords) 
        {
            if (isTooCloseToCenter(coords) == false)
            {
            if (isFirstEnemy() == true) return true;  

            else if (isTooCloseToEnemy(coords) == false) return true;

            else return false;
            }
            else return false;

        
        }
    //checks if given coordinates are good for spawning an enemy
    private Vector3 generateEnemyCoords() 
    {
        Vector3 coords = generateCoords();
        while (isCoordGood(coords) == false)coords = generateCoords();
        return coords;
    }
    //returns coordinates for enemy spawn
    public void delete(GameObject obj)
    {
        enemyInstances.Remove(obj);
        Destroy(obj); 
    }
    //method for simply deleting an enemy object and removing it from its array list
    private void instantiateMass(GameObject obj)
    {
        float playerMass = GameObject.Find("Player").GetComponent<Mass>().getMass();
        
        if(obj.CompareTag("Food")){
            obj.GetComponent<Mass>().setMass(Random.Range(0.3f, 4));
        }
        else if(obj.CompareTag("Killer")){
            obj.GetComponent<Mass>().setMass(Random.Range(10, 20));
        }
    }
    //sets the mass of enemy object when spawned
    public void updateMassScore() 
    {
        scoreText.text = "Mass: " + GameObject.Find("Player").GetComponent<Mass>().getMass().ToString("0.##");
    }
    //updates the ui that displays mass
    public void RestartGame()
    {
     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    //reloads the scene to restart game

    public void goLvl2()
    {
     SceneManager.LoadScene("Stage 2");
    }
    //changes scene to stage2

    public void endGameScreen()
    {       
            if(winGame == true){nextlvltbutton.gameObject.SetActive(true);}
            
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            mainMenuButton.gameObject.SetActive(true);
    }
    //shows end game screen
}
