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
    public int TotalCoins;
    public string ItemType;

    private void Awake()
    {
        instance = this;
        TotalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        Coins = TotalCoins;
        mycoins.text = Coins.ToString();
        totaltcoins.text = TotalCoins.ToString();
    }
    public void start()
    {
        TotalCoins = PlayerPrefs.GetInt("TotalCoins",TotalCoins);
        mycoins.text = Coins.ToString();
        totaltcoins.text = TotalCoins.ToString();
    }
    public void Addcoin()
    {
        Coins +=1;
        mycoins.text = Coins.ToString();
        save();
        // if(TotalCoins < Coins)
        // {
        //     PlayerPrefs.SetInt("TotalCoins", Coins);
        // }
    }

    public void save()
    {
       PlayerPrefs.SetInt("TotalCoins",Coins);
    }
    
    public void load()
    {
        TotalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        Coins = TotalCoins;
        mycoins.text = Coins.ToString();
        totaltcoins.text = TotalCoins.ToString();
    }

    public void Resetcoin()
    {
        PlayerPrefs.DeleteKey("TotalCoins");
    }
}
