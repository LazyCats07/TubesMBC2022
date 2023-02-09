using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OP : MonoBehaviour
{
    [SerializeField]
    GameObject Frame1;
    [SerializeField]
    GameObject Frame2;
    [SerializeField]
    GameObject Frame3;
    [SerializeField]
    GameObject Frame4;
    [SerializeField]
    GameObject Frame5;
    [SerializeField]
    GameObject Frame6;

    [SerializeField]
    GameObject Battle3;

    public void next1()
    {
        Frame2.SetActive(true);
        Time.timeScale = 0f;
        Frame1.SetActive(false);
        Time.timeScale = 1f;
    }

    public void next2()
    {
        Frame3.SetActive(true);
        Time.timeScale = 0f;
        Frame2.SetActive(false);
        Time.timeScale = 1f;
    }

    public void next3()
    {
        Frame4.SetActive(true);
        Time.timeScale = 0f;
        Frame3.SetActive(false);
        Time.timeScale = 1f;
    }

    public void next4()
    {
        Frame5.SetActive(true);
        Time.timeScale = 0f;
        Frame4.SetActive(false);
        Time.timeScale = 1f;
    }

    public void next5()
    {
        Frame6.SetActive(true);
        Time.timeScale = 0f;
        Frame5.SetActive(false);
        Time.timeScale = 1f;
    }

    public void next6()
    {
        Frame6.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Tutorial_RoamingAwal");
    }

    public void bth()
    {
        Frame3.SetActive(false);
        Time.timeScale = 0f;
        Battle3.SetActive(true);
        Time.timeScale = 1f;
    }

    public void Final()
    {
        Frame2.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Area5_Combat");
    }
}
