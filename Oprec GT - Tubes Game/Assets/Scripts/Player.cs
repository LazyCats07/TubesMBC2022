using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float health;
    public float lerpTimer;
    public float maxHealth = 100;
    public float chipSpeed = 2f;
    public Image frontHealthBar; 
    public Image backHealthBar;
    public Text HpText;
    public int level;
    public float currentXp;
    public float requiredXp;

    public float delayTimer; 

    public Image frontXpBar;
    public Image backXpBar;

    public Text XpText;
    public Text LevelText;

    private int i=1;
    public int Damage;
    
    
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        frontXpBar.fillAmount = currentXp / requiredXp;
        backXpBar.fillAmount = currentXp / requiredXp;
        LevelText.text = "Level " + level;
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);      
        // takedamage(20);
        UpdateHealthUI();
        // if(Input.GetKeyDown(KeyCode.Escape))
        // {
        //     TakeDamage(Random.Range(5 , 10));
        // }
        UpdateXpUI();
        // GetComponent<BattleSystem>();
        // exp = Win.SetActive();
        // if(exp == true)
        if(i<1)
            GainExperienceFlatRate(0);
            i++;
        if(currentXp > requiredXp)
            LevelUp();
    }

    public void UpdateHealthUI()
    {
        //Debug.Log(health);
        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFraction = health / maxHealth;
        if(fillB > hFraction)
        {
            frontHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            backHealthBar.fillAmount = Mathf.Lerp(fillB,hFraction,percentComplete);
        }
        HpText.text = Mathf.Round(health) + "/" + Mathf.Round(maxHealth);
    }

    // public void giveDamage(int Damage)
    // {
    //     player = GetComponent<LevelSystem>();
    //     Damage = 20 * player.level;
    //     health -= Damage;
    //     lerpTimer = 0f;
    // }

    // public void restoreHealth(float healAmount)
    // {
    //     health += healAmount;
    //     lerpTimer = 0f;
    // }

    public void IncreaseHealth(int level)
    {
        maxHealth += (10 * level);
        health = maxHealth;
    }

    public void UpdateXpUI()
    {
        //Debug.Log(requiredXp);
        float xpFraction = currentXp / requiredXp;
        float FXP = frontXpBar.fillAmount;
        if(FXP < xpFraction)
        {
            delayTimer += Time.deltaTime;
            backXpBar.fillAmount = xpFraction;
            if(delayTimer > 3)
            {
                lerpTimer += Time.deltaTime;
                float percentComplete = lerpTimer / 4;
                frontXpBar.fillAmount = Mathf.Lerp(FXP, backXpBar.fillAmount, percentComplete);
            }
        }
        XpText.text = currentXp + "/" + requiredXp;
    }

    public void GainExperienceFlatRate(float xpGained)
    {
        currentXp += xpGained;
        PlayerPrefs.SetFloat("Exp", currentXp);
        lerpTimer = 0f;
    }


    public void GainExperienceScalable(float xpGained, int passedLevel)
    {
        if(passedLevel < level)
        {
            float multiplier = 1;
            currentXp += xpGained * multiplier;
        }
        else
        {
            currentXp += xpGained;
        }
        lerpTimer = 0f;
        delayTimer = 0f;
    }

    public void GetExpSaved()
    {
        currentXp = PlayerPrefs.GetFloat("Exp");
    }

    public void ResetLevel()
    {
        PlayerPrefs.DeleteKey("Exp");
        currentXp = 0;
        level = 1;
    }

    public void LevelUp()
    {
        level++;
        frontXpBar.fillAmount = 0f;
        backXpBar.fillAmount = 0f;
        currentXp = Mathf.RoundToInt(currentXp - requiredXp);
        IncreaseHealth(level);
        requiredXp += 15 * level;
        LevelText.text = "Level " + level;
    }
    
    // public void TakeDamage(int Damage)
    // {
    //     if(health >= 0)
    //     // {   Damage = Random.Range(20, 51);
    //         health -= Damage;
    //     //}
    //     else return true;
    // }
}
