using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}

public class Battle : MonoBehaviour
{
    public GameObject GameOver;
    public GameObject Win;
    public BattleState state;
    bool isDead = false;
    Player playerUnit;
    Mob mobUnit;



    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        GetComponent<LevelSystem>().GetExpSaved();
        SetupBattle();
    }

    void SetupBattle()
    {
        state = BattleState.PLAYERTURN;

    }

    void PlayerAttack()
    {   
        // bool isDead = mobUnit.TakeDamage(playerUnit.Damage);


        // if(isDead == true)
        // {
        //     state = BattleState.WON;
        //     EndBattle();
        // }
        // else
        // {
        //     state = BattleState.ENEMYTURN;
        
        // }
    }

    void EnemyTurn()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndBattle()
    {
        if(state == BattleState.WON)
        {
            win();
        }
        else if (state == BattleState.LOST)
        {
            end();
        }
    }


    public void end()
    {
        GameOver.SetActive(true);
        Time.timeScale = 0f;
        GetComponent<LevelSystem>().ResetLevel();
    }

    public void OnAttackButton()
    {
        GetComponent<Mob>().TakeDamage(10);
    }
    
    public void win()
    {
        Win.SetActive(true);
        Time.timeScale = 0f;
        // bool isDead = mobUnit.TakeDamage(playerUnit.giveDamage);
        // if(isDead)
            GetComponent<LevelSystem>().GainExperienceFlatRate(20);
    }

    public void OnNextButton1()
    {
        SceneManager.LoadScene("Tutorial_Roaming");
    }

    public void Title()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void OnEndButton()
    {
        state = BattleState.ENEMYTURN;
    }
}
