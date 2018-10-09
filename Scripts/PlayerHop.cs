using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHop : MonoBehaviour {

    public GameObject Door;                        //To look at the door
    public float speed;                            //For the distance you make each hop
    public KeyCode fowards;                        //FOr the key you need to press to make it go forwards
    public int points;                             //To keep track of the points you get

    public Text scoreMeter;                        //The next three are simple texts to make them say something
    public Text FinalScore;
    public Text GameOver;
    public GameObject Scoring;                    //The next four game objects are for calling them into the scene and make them dissapear when they are not needed
    public GameObject mainmenu;
    public GameObject scoresis;
    public GameObject mainfinish;


    //public BoolTrigger Trigger;
	// Use this for initialization
	void Start ()
    {
        transform.LookAt(Door.transform);              //Looks at the door assined earlier
        points = 0;                                    //Sets the points to 0 and then makes the other texts that are not needed dissapear.
        Scoring.SetActive(false);
        mainmenu.SetActive(false);
        mainfinish.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Door.transform);                        //If the door ever changes position, the player will always look at it
        if (Input.GetKeyDown(fowards    ))                       //If you press the key assigned to the key code, then do the following:
        {
            transform.position = Vector3.MoveTowards(transform.position, Door.transform.position, speed);  //Changes the position by the amount of speed
            points += 10;                                                                                  //Adds 10 points to the score
            
        }

        scoreMeter.text = "Score: " + points.ToString();                          //After all that, the score is sent to the text dysplaying it       
	}


     public void OnTriggerEnter(Collider walls)                               //If something enter the colloder, do this
    { 
      if (walls.CompareTag("Monster"))                                       //If the thing that entered the collider has a tag like this one, do this:
     {
            FinalScore.text = "Your score: " + points.ToString();
            GameOver.text = "GAME OVER";
            Scoring.SetActive(true);
            scoresis.SetActive(false);
            mainmenu.SetActive(true);
            Time.timeScale = 0;

        }

      if (walls.CompareTag("Door"))                                       //If the thing that entered the collider has a tag like this one, do this:
        {
            points += 520;                                                //Adds additional points to round up to 2500, this is not accurate and needs updating
            FinalScore.text = "Your score: " + points.ToString();        //Sends it to a text that appears after you win
            GameOver.text = "YOU SCAPED!";                               //Tells you that you scaped by text
            Scoring.SetActive(true);                                     //The next three commands make the things appear on screen
            mainfinish.SetActive(true);
            scoresis.SetActive(false);
            Time.timeScale = 0;                                          //Makes everything stop while still funtional. Think it as puasing the game
        }

      if (walls.CompareTag("Axe"))                                        //If the thing that entered the collider has a tag like this one, do this:
        {
            points += -20;                                              //Subtracks some of your points
        }
      
    }
}
