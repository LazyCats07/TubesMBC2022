using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HuangLongCutScene : MonoBehaviour
{
    [SerializeField]
    GameObject Frame1;
    [SerializeField]
    GameObject Frame2;
    [SerializeField]
    GameObject Frame3;
    [SerializeField]
    GameObject Frame4;

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
        Frame4.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Area4_Combat");
        
        
    }

}
