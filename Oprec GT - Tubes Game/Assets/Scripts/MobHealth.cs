using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MobHealth : MonoBehaviour
{
    public float Health;
    public float lerpTimer;
    public float MaxHealth = 30;
    public float chipSpeed = 2f;
    public Image FrontHealthBar;
    public Image BackHealthBar;
    public Text HPText;

    // Start is called before the first frame update
    void Start()
    {
        Health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Health = Mathf.Clamp(Health, 0, MaxHealth);
        UpdatehealthUI();
    }

    public void UpdatehealthUI()
    {
        //Debug.Log(health);
        float fillF = FrontHealthBar.fillAmount;
        float fillB = BackHealthBar.fillAmount;
        float HFraction = Health / MaxHealth;
        if(fillB > HFraction)
        {
            FrontHealthBar.fillAmount = HFraction;
            BackHealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            BackHealthBar.fillAmount = Mathf.Lerp(fillB,HFraction,percentComplete);
        }
        HPText.text = Mathf.Round(Health) + "/" + Mathf.Round(MaxHealth);
    }

    // public void giveDamage(int Damage)
    // {
    //     player = GetComponent<LevelSystem>();
    //     Damage = 20 * player.Level;
    //     health -= Damage;
    //     lerpTimer = 0f;
    // }

    // public void restoreHealth(float healAmount)
    // {
    //     health += healAmount;
    //     lerpTimer = 0f;
    // }

    public void TakeDamage(int Damage)
    {
        Health -= (2 * Damage);

        // if(Health <=0)
        //     return true;
        // else
        // {
        //     return false;
        // }
    }

    public void increaseHealth(int Level)
    {
        MaxHealth += (5 * Level);
        Health = MaxHealth;
    }
}
