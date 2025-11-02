using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
   //timer & score
    public TextMesh timerText;
    public TextMesh scoreText;
    public int score;
    public float gameTimer;
    bool TimerTrue;

    //audio
    AudioSource clockTick;
    AudioSource gameOver;
    public AudioSource whack;
    bool overSoundPlayed;

    // MOLE VARIABLES
    public GameObject moleContainer;
    public GameObject machine;

    //array for moles inside container
    private MoleScript[] moles;

    //show mole every 1.5 seconds 
    public float showMoletimer = 1.2f;

    void Start()
    {
        //timer set to 0
        gameTimer = 0f;
        timerText.text = "Press Start To Play";

        //prepare audio sources
        whack = moleContainer.GetComponent<AudioSource>();
        gameOver = machine.GetComponent<AudioSource>();
        clockTick = GetComponent<AudioSource>();

    }

    public void StartButtonPressed()
    {
        if (gameTimer <= 0)
        {
            //put all moles from molecontainer into mole array
            moles = moleContainer.GetComponentsInChildren<MoleScript>();
            
            //set variables to (re)start game
            score = 0;
            gameTimer = 45f;

            //start clock sound
           
            clockTick.Play(0);

            //set timer is going boolean to true
            TimerTrue = true;

            //set gameOver sound bool back to unplayed
            overSoundPlayed = false;
            
        }
    }
    
    void Update()
    {

        if (TimerTrue == true)
        {
            //subtracts 1 second from game timer
            gameTimer -= Time.deltaTime;
          
        }
        

        //check game timer is greater than 0 
        if (gameTimer > 0f)
        {
            //update text in unity
            timerText.text = "GAME TIME: " + Mathf.Floor(gameTimer);

            showMoletimer -= Time.deltaTime;
            //show mole is showmoletimer is 0
            if (showMoletimer < 0f)
            {
                //show random mole 
                moles[Random.Range(0, moles.Length)].showMole();

                //reset show mole timer
                showMoletimer = 1.2f;
            }
        }

        // game timer less than 0 seconds
        else if (gameTimer < 0)
        {
            //change to game over text
            timerText.text = "GAME OVER";
            
            //timer boolean set to false
            TimerTrue = false;

            //pause clock ticking noise
            clockTick.Stop();
            
            //if the gameover sound has not already been played, play it now, and set bool to show it has played. 
            if (overSoundPlayed == false)
            {
                gameOver.Play(0);
                overSoundPlayed = true;
            }
        }
        
      
    }
}
