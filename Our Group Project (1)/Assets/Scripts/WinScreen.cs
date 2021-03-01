using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public void Main()
    {
        SceneManager.LoadScene("Main Menu");
    }
    
    public void QuitGame ()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }
}