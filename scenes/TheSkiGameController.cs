using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheSkiGameController : MonoBehaviour
{
    //timer & score text & variables
    public TextMesh timerText;
    public TextMesh scoreText;
    public int score;
    public float gameTimer;
    bool TimerTrue;
   

    //audio
    public GameObject backboard;
    public GameObject screenplate;
    public GameObject machine;
    AudioSource clockTicking;
    AudioSource gameOver;
    bool gameOverPlayed;

    void Start()
    {   //set game timer to 0
        gameTimer = 0f;

        //update text with introduction message
        timerText.text = "Press Play To Start";

        //get audio sources
        clockTicking = GetComponent<AudioSource>();
        gameOver = machine.GetComponent<AudioSource>();

    }

    //if play button is pressed (and game is not currently in session)
    public void SkiStartButtonPressed()
    {
        if (gameTimer <= 0)
        {
         
            //set variables to (re)start game
            score = 0;
            gameTimer = 45f;

            //update text in unity
            scoreText.text = "Score: " + Mathf.Floor(score);
            timerText.text = "Score: " + Mathf.Floor(score);

            //timer is now running
            TimerTrue = true;
            
            //start clock sound
            clockTicking.Play(0);
            
            //set gameOver sound bool back to unplayed
            gameOverPlayed = false;
        }
    }

    void Update()
    {
        //if timer is going, update text in unity
        if (TimerTrue == true)
        {
            //subtracts 1 second from game timer
            gameTimer -= Time.deltaTime;

        }


        //if game timer is greater than 0, display this text 
        if (gameTimer > 0f)
        {
            //update text in unity to 
            timerText.text = "GAME TIME: " + Mathf.Floor(gameTimer);

        }

        // game timer less than 0 seconds
        else if (gameTimer < 0)
        {
            //set text to gameover
            timerText.text = "GAME OVER";
            
            //timer is no longer going
            TimerTrue = false;
            
            //stop ticking sound
            clockTicking.Stop();

            //if the gameover sound has not already been played, play it now, and set bool to show it has played. 
            if (gameOverPlayed == false)
            {
                gameOver.Play(0);
                gameOverPlayed = true;
            }
        }

    }
}

