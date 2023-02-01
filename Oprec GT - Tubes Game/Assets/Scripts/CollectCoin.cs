using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollectCoin : MonoBehaviour
{ 
    public static CollectCoin instance;
    public Text CoinVal;
    private int koin = 0;
    private int intvalue;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        CoinVal.text = PlayerPrefs.GetInt("newvalue", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addC()
    {
        koin++;
        intvalue = koin;
    }

    public void save()
    {
        PlayerPrefs.SetInt("newvalue",intvalue);
    }
    
    public void load()
    {
        CoinVal.text = PlayerPrefs.GetInt("newvalue", 0).ToString();
    }
    
    public void hapus()
    {
        PlayerPrefs.DeleteKey("newvalue");
    }
}
