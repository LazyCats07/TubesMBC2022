using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField]
    GameObject PauseMenu;
    [SerializeField]
    GameObject bg1;
    [SerializeField]
    GameObject bg2;
    
    

    public void Pausee()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 0f;
        bg1.SetActive(true);
        Time.timeScale = 1f;
        bg2.SetActive(true);
        Time.timeScale = 1f;
    }
    public void Title()
    {
        SceneManager.LoadScene("Main Menu");
    }

   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 0f;
            bg1.SetActive(true);
            Time.timeScale = 1f;
            bg2.SetActive(true);
            Time.timeScale = 1f;
        }
    }

}

