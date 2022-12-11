using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Talkmenu : MonoBehaviour
{   

    public GameObject TalkMenu;


    public void talk()
    {
        TalkMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void No1()
    {
        TalkMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Yes1()
    {
        SceneManager.LoadScene("Tutorial_Roaming");
    }

    public void Yes2()
    {
        SceneManager.LoadScene("Area2_Roaming");
    }

    public void Yes3()
    {
        SceneManager.LoadScene("Area3_Roaming");
    }

    public void Yes32()
    {
        SceneManager.LoadScene("Area3_Roaming 2");
    }

    public void Yes33()
    {
        SceneManager.LoadScene("Area3_Roaming 3");
    }

    public void Exit()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Scene4()
    {
        SceneManager.LoadScene("DeadHL");
    }

    public void Ending()
    {
        SceneManager.LoadScene("ED_Cutscene");
    }

}
