using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    [SerializeField]
    GameObject Quit;
    [SerializeField]
    GameObject MainMenu;

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Game Ended");
        // Quit.SetActive(true);
        // Time.timeScale = 1f;
        // MainMenu.SetActive(false);
        // Time.timeScale = 0f;
        GameObject.Find("Audio_MainMenu").GetComponent<AudioSource>().Stop();
    }

    public void Play()
    {
        GameObject.Find("Audio_MainMenu").GetComponent<AudioSource>().Stop();
        SceneManager.LoadScene("OP_Cutscene");
        Time.timeScale = 1f;
    }

    

}
