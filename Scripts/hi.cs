using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hi : MonoBehaviour
{

    public void change()
    {
        Time.timeScale = 1;                                          //This makes the game run normally again
        SceneManager.LoadScene("Player and monster testing");        //This changes scenes to the last scene
    }
}
