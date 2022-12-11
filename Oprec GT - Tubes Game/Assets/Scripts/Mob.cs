using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mob : MonoBehaviour
{
    
    public float Health;
    public float lerpTimer;
    public float MaxHealth = 30;
    public float chipSpeed = 2f;
    public int damage;
    public Image FrontHealthBar;
    public Image BackHealthBar;
    public Text HPText;
    public int Level;
    public Text levelText;
    public Text Mobname;
    public int touch;
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;
    public GameObject enemyPrefab4;
    public Transform enemyBattleStation;

    // Start is called before the first frame update
    void Start()
    {
        Health = MaxHealth;
        Spawn();
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

    // public void TakeDamage(int Damage)
    // {
    //     Health -= (2 * Damage);

    //     // if(Health <=0)
    //     //     return true;
    //     // else
    //     // {
    //     //     return false;
    //     // }
    // }

    public void increaseHealth(int Level)
    {
        MaxHealth += (5 * Level);
        Health = MaxHealth;
    }

    

    public void Spawn()
    {
        touch = Random.Range(1, 5);
        if(touch == 1)
        {
            Level = Random.Range(1, 3);
            levelText.text = "Level " + Level;
            Mobname.text = "Slime";
            GetComponent<MobHealth>().increaseHealth(Level);
            GameObject enemyGo = Instantiate(enemyPrefab1, enemyBattleStation);
        }

        if(touch == 2)
        {
            Level = Random.Range(1, 3);
            levelText.text = "Level " + Level;
            Mobname.text = "Fairy";
            GetComponent<MobHealth>().increaseHealth(Level);
            GameObject enemyGo = Instantiate(enemyPrefab2, enemyBattleStation);
        }

        if(touch == 3)
        {
            Level = Random.Range(3, 5);
            levelText.text = "Level " + Level;
            Mobname.text = "Imp";
            GetComponent<MobHealth>().increaseHealth(Level);
            GameObject enemyGo = Instantiate(enemyPrefab3, enemyBattleStation);
        }

        if(touch == 4)
        {
            Level = Random.Range(5, 7);
            levelText.text = "Level " + Level;
            Mobname.text = "Skeleton Mage";
            GetComponent<MobHealth>().increaseHealth(Level);
            GameObject enemyGo = Instantiate(enemyPrefab4, enemyBattleStation);
        }
    }
    
    public void TakeDamage(float damage)
    {
        Health -= damage;
    }

    // public void TakeDamage(int damage)
    // {
    //     if(Health >= 0)
    //     //{   damage = Random.Range(10, 41);
    //         Health -= damage;
    //     //}
    //     else return true;
    // }
}
