using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sc : MonoBehaviour {

    public void change()
    {
        Time.timeScale = 1;                                  //This makes the game run normally again
        SceneManager.LoadScene("Sala uno");                  //This makes the game go back to the main menu
    }
}
