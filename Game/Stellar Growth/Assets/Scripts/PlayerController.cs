using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private int life;
    public ParticleSystem explosionParticle;
    private Mass playerMass;
    private GameManager manager;
    public AudioClip pow;
    private AudioSource playerAudio;
    public GameObject [] lives;
    // array that stores the life image sprites
    public int growthFactor = 5;
    // Start is called before the first frame update
    void Start()
    {
        life =3; // sets the starting lives

        playerAudio = GetComponent<AudioSource>();
        playerMass = GameObject.Find("Player").GetComponent<Mass>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void zoomOutCam()
    {
        Vector3 camPos = GameObject.Find("Main Camera").transform.position;
        GameObject.Find("Main Camera").transform.position = new Vector3(0, camPos.y + 2, camPos.z - 1);
    }
    // zooms out camera when called
    private void doBigPow()
    {
        playerAudio.PlayOneShot(pow, 1);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
    }
    // method for explosion and particle effect on crashing into another body
    private void hideHearts(){
        lives[life].SetActive(false);
    }
    // hides hearts to match the amount of lives

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Food"))
        {
            if (collision.gameObject.GetComponent<Mass>().getMass() < playerMass.getMass() * 1.3f)
            {
                doBigPow();
                playerMass.setMass(playerMass.getMass() + (collision.gameObject.GetComponent<Mass>().getMass() / growthFactor));
                manager.delete(collision.gameObject);
                zoomOutCam();
            }// if the object is small enough to be eaten, grow mass of player 

            else if (life > 0){
                life--;
                hideHearts();
                doBigPow();
                manager.delete(collision.gameObject);
            }// if lifes are more than 0 delete enemy and continue

            else if(life <= 0){
                doBigPow();
                GameObject.Find("GameManager").GetComponent<GameManager>().gameOver = true;
            }
            //ends game if you run out of lives
        }

        else if (collision.gameObject.CompareTag("Killer"))
        {
            doBigPow();
            GameObject.Find("GameManager").GetComponent<GameManager>().gameOver = true;
        }
        //ends game if you collide with a killer object
    }
}
