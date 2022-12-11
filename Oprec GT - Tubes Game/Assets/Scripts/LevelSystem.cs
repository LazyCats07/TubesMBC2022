using System.Threading;
using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    public int level;
    public float currentXp;
    public float requiredXp;

    public float lerpTimer;
    public float delayTimer; 

    public Image frontXpBar;
    public Image backXpBar;

    public Text XpText;
    public Text LevelText;

    private int i=1;


    // Start is called before the first frame update
    void Start()
    {
        frontXpBar.fillAmount = currentXp / requiredXp;
        backXpBar.fillAmount = currentXp / requiredXp;
        LevelText.text = "Level " + level;
    }

    // Update is called once per frame
    void Update()
    {
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
        GetComponent<PlayerHealth>().IncreaseHealth(level);
        GetComponent<MpPlayer>().IncreaseMana(level);
        requiredXp += 15 * level;
        LevelText.text = "Level " + level;
    }

}
