using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectables : MonoBehaviour
{   
    public static Collectables instance;
    public Text mycoins;
    public Text totaltcoins;
    int Coins = 0;
    int TotalCoins = 0;
    //public string ItemType;

    private void Awake()
    {
        instance = this;
    }
    public void start()
    {
        TotalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        mycoins.text = Coins.ToString();
        totaltcoins.text = TotalCoins.ToString();
    }
    public void Addcoin()
    {
        Coins +=1;
        mycoins.text = Coins.ToString();
        if(TotalCoins < Coins)
        {
            PlayerPrefs.SetInt("TotalCoins", Coins);
        }
    }
    public void Reset()
    {
        PlayerPrefs.DeleteKey("TotalCoins");
    }
}
