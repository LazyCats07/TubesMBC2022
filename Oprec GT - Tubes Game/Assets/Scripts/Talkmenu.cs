using System.Threading;
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
        Time.timeScale = 1f;
    }
    public void No1()
    {
        TalkMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Yes1()
    {
        SceneManager.LoadScene("Tutorial_Roaming");
        Time.timeScale = 1f;
    }

    public void Yes2()
    {
        SceneManager.LoadScene("Area2_Roaming");
        Time.timeScale = 1f;
    }

    public void Yes3()
    {
        SceneManager.LoadScene("Area3_Roaming");
        Time.timeScale = 1f;
    }

    public void Yes32()
    {
        SceneManager.LoadScene("Area3_Roaming2");
        Time.timeScale = 1f;
    }

    public void Yes33()
    {
        SceneManager.LoadScene("Area3_Roaming3");
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
    }

    public void Scene4()
    {
        SceneManager.LoadScene("DeadHL");
        Time.timeScale = 1f;
    }

    public void Ending()
    {
        SceneManager.LoadScene("ED_Cutscene");
        Time.timeScale = 1f;
    }

    public void Area2()
    {
        SceneManager.LoadScene("Area2_Roaming2");
        Time.timeScale = 1f;
    }

}
