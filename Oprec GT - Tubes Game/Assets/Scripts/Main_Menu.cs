using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }

    public void Play()
    {
        SceneManager.LoadScene("OP_Cutscene");
        Time.timeScale = 1f;
    }

}
