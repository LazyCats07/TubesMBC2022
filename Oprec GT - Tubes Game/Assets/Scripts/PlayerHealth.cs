using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    
    public float health;
    public float lerpTimer;
    public float maxHealth = 100;
    public float chipSpeed = 2f;
    public Image frontHealthBar; 
    public Image backHealthBar;
    public Text HpText;
    LevelSystem player;
    
    
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
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

    public void giveDamage(int Damage)
    {
        player = GetComponent<LevelSystem>();
        Damage = 20 * player.level;
        health -= Damage;
        lerpTimer = 0f;
    }

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

}
