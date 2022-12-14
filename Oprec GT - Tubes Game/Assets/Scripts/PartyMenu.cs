using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyMenu : MonoBehaviour
{
    [SerializeField]
    GameObject Party;
    [SerializeField]
    GameObject Stats;
    [SerializeField]
    GameObject bg1;
    [SerializeField]
    GameObject bg2;
    [SerializeField]
    GameObject PauseMenu;

    public void Partyy()
    {
        Party.SetActive(true);
        Time.timeScale = 0f;
        Stats.SetActive(true);
        Time.timeScale = 0f;
        bg1.SetActive(false);
        Time.timeScale = 0f;
        bg2.SetActive(false);
        Time.timeScale = 0f;
        PauseMenu.SetActive(false);
        Time.timeScale = 0f;

    }
    public void Resume()
    {
        Party.SetActive(false);
        Time.timeScale = 0f;
        Stats.SetActive(false);
        Time.timeScale = 0f;
        PauseMenu.SetActive(true);
        Time.timeScale = 1f;
        bg1.SetActive(true);
        Time.timeScale = 0f;
        bg2.SetActive(true);
        Time.timeScale = 0f;
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            Party.SetActive(false);
            Time.timeScale = 0f;
            Stats.SetActive(false);
            Time.timeScale = 0f;
            PauseMenu.SetActive(true);
            Time.timeScale = 1f;
            bg1.SetActive(true);
            Time.timeScale = 0f;
            bg2.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
