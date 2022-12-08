using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Talkmenu : MonoBehaviour
{
    [SerializeField]
    GameObject TalkMenu;

    public void Talk()
    {
        TalkMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        TalkMenu.SetActive(false);
        Time.timeScale = 1f;
    }

}
