using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MpPlayer : MonoBehaviour
{
    public float Mana;
    public float lerpTimer;
    public float maxMana = 50;
    public float chipSpeed = 2f;
    public Image frontMpBar; 
    public Image backMpBar;
    public Text MpText;
    LevelSystem player;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Mana = maxMana;
    }

    // Update is called once per frame
    void Update()
    {
        Mana = Mathf.Clamp(Mana, 0, maxMana);      
        // takedamage(20);
        UpdateManaUI();
        // if(Input.GetKeyDown(KeyCode.Escape))
        // {
        //     TakeDamage(Random.Range(5 , 10));
        // }
    }

    public void UpdateManaUI()
    {
        //Debug.Log(Mana);
        float fillF = frontMpBar.fillAmount;
        float fillB = backMpBar.fillAmount;
        float mFraction = Mana / maxMana;
        if(fillB > mFraction)
        {
            frontMpBar.fillAmount = mFraction;
            backMpBar.color = Color.blue;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            backMpBar.fillAmount = Mathf.Lerp(fillB,mFraction,percentComplete);
        }
        MpText.text = Mathf.Round(Mana) + "/" + Mathf.Round(maxMana);
    }

    // public void giveDamage(int Damage)
    // {
    //     player = GetComponent<LevelSystem>();
    //     Damage = 20 * player.level;
    //     health -= Damage;
    //     lerpTimer = 0f;
    // }

    public void IncreaseMana(int level)
    {
        maxMana += (5 * level);
        Mana = maxMana;
    }

}
