using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class SceneLoader : MonoBehaviour
{

   

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ReloadGame()
    {
        Debug.Log("Again");
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }


}
