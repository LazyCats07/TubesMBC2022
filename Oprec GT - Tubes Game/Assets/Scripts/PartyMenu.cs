using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyMenu : MonoBehaviour
{
    [SerializeField]
    GameObject Party;

    public void Partyy()
    {
        Party.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        Party.SetActive(false);
        Time.timeScale = 1f;
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
         Party.SetActive(false);
         Time.timeScale = 0f;
        }
    }
}
