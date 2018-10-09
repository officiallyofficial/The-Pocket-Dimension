using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour {

    public KeyCode quit;
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(quit))                      //If at any moment you hit the key assined to the key code "quit" then the next part will run
        {
            Application.Quit();                          //Pretty self explanatory
        }
	}
}
