using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkiballScript: MonoBehaviour
{
    //values for ball return spawn
    public float BallReturnX;
    public float BallReturnY;
    public float BallReturnZ;

    //audio sources
    AudioSource HoleSound;
    AudioSource point;

    //rigidbody for ball
    Rigidbody ballBody;
    
    

    //Mole is Created
    private void Awake()
    {
       //set ball return coordinates
       BallReturnX = -0.043f;
       BallReturnY = 0.551f;
       BallReturnZ = 3.801f;

       //grab rigid body component of ball
       ballBody = GetComponent<Rigidbody>();
    }

    

    // Update is called once per frame
    void Update()
    {
       

    }



    //collision between ball and hole
    void OnCollisionEnter(Collision collision)
    {
        //reference other script
        GameObject TheSkiGameController = GameObject.Find("TheSkiGameController");
        TheSkiGameController TheSkiGameControllerScript = TheSkiGameController.GetComponent<TheSkiGameController>();

        //grab audio component for point sound
        point = TheSkiGameControllerScript.screenplate.GetComponent<AudioSource>();
       

        //if ball collides with collider worth points, add points to score and call return ball function
            if (collision.collider.name == "100")
            {
                //increase score
                TheSkiGameControllerScript.score += 100;
                
                //play sound if game is going
                 if  (TheSkiGameControllerScript.gameTimer > 0)
                    {
                      point.Play();
                    }
                
                 returnBall();
            }

            if (collision.collider.name == "50")
            {
                //increase score
                TheSkiGameControllerScript.score += 50;

                //play sound if game is going
                 if (TheSkiGameControllerScript.gameTimer > 0)
                 {
                    point.Play();
                 }

            returnBall();
            }

            if (collision.collider.name == "30")
            {
                //increase score
                TheSkiGameControllerScript.score += 30;

                //play sound if game is going
                if (TheSkiGameControllerScript.gameTimer > 0)
                {
                   point.Play();
                }

            returnBall();
            }

            if (collision.collider.name == "20")
            {
                //increase score
                TheSkiGameControllerScript.score += 20;

                //play sound if game is going
                if (TheSkiGameControllerScript.gameTimer > 0)
                {
                    point.Play();
                }

            returnBall();
            }

            if (collision.collider.name == "10")
            {
                //increase score
                TheSkiGameControllerScript.score += 10;

                //play sound if game is going
                if (TheSkiGameControllerScript.gameTimer > 0)
                {
                    point.Play();
                }

            returnBall();
            }

            if (collision.collider.name == "0")
            {
                returnBall();
            }

            if (collision.collider.name == "Floor")
            {
                returnBall();
            }
                
    }
        //return the ball, play sound effects and update points
        public void returnBall()
        {
            //reference other script
             GameObject TheSkiGameController = GameObject.Find("TheSkiGameController");
             TheSkiGameController TheSkiGameControllerScript = TheSkiGameController.GetComponent<TheSkiGameController>();

             //put ball into ball return and set velocity to 0
                transform.localPosition = new Vector3(BallReturnX, BallReturnY, BallReturnZ);
                ballBody.velocity = new Vector3(0.0f, 0, 0);

              //grab necessary audio component
                HoleSound = TheSkiGameControllerScript.backboard.GetComponent<AudioSource>();

              //play audio 
                HoleSound.Play();

            //update text on scoreboard if game is currently being played
            if (TheSkiGameControllerScript.gameTimer > 0)
                {
                    TheSkiGameControllerScript.scoreText.text = "Score: " + Mathf.Floor(TheSkiGameControllerScript.score);
                    
                }  
         }

}
