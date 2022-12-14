using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Talkmenu : MonoBehaviour
{   

    public GameObject TalkMenu;
    public GameObject bg1;
    public GameObject bg2;
    public GameObject Battle;
    public GameObject Skill;
    public GameObject Win;


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
        TalkMenu.SetActive(false);
        Time.timeScale = 0f;
        Skill.SetActive(false);
        Time.timeScale = 0f;
        Battle.SetActive(false);
        Time.timeScale = 0f;
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

    public void OnWinBUtton()
    {
        TalkMenu.SetActive(false);
        Time.timeScale = 0f;
        Skill.SetActive(false);
        Time.timeScale = 0f;
        Battle.SetActive(false);
        Time.timeScale = 0f;
        Win.SetActive(false);
        Time.timeScale = 0f;
        bg1.SetActive(true);
        Time.timeScale = 1f;
        bg2.SetActive(true);
        Time.timeScale = 1f;
    }
}
