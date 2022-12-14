using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}

public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;
    public GameObject Win;
    public GameObject GameOver;
    public GameObject Skill;
    

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;

    public Text dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public BattleState state;
    

    void Start()
    {
        
        state = BattleState.START;
        //StartCoroutine(SetupBattle());
        SetupBattle();
            
    }

    void SetupBattle()
    {  
        state = BattleState.PLAYERTURN;
        PlayerTurn();

        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();
        
        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        dialogueText.text = "An Evil " + enemyUnit.unitName + " Approaches...";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        //yield return new WaitForSeconds(2f);

        
    }

    void PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
       
        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogueText.text = "The attack is successful!";

        //yield return new WaitForSeconds(1f); 

        if(isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            //StartCoroutine(EnemyTurn());
            EnemyTurn();
        }

    }

    void EnemyTurn()
    {
        dialogueText.text = enemyUnit.unitName + " Attacks!";

        //yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        playerHUD.SetHP(playerUnit.currentHP);

        //yield return new WaitForSeconds(1f);

        if(isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void EndBattle()
    {
        if(state == BattleState.WON)
        {
            Win.SetActive(true);
            Time.timeScale = 0f;
            Collectables.instance.Addcoin();
            SetupBattle();
        
        }
        else if(state == BattleState.LOST)
        {
            GameOver.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    void PlayerTurn()
    {
        dialogueText.text = "Choose an action:";
    }

    public void OnAttackButton()
    {
        if(state != BattleState.PLAYERTURN)
            return;

        //StartCoroutine(PlayerAttack());
        PlayerAttack();
    }

    public void onSkillButton()
    {
        if(state != BattleState.PLAYERTURN)
            return;
        Skill.SetActive(true);
        Time.timeScale = 0f;
    }

    public void onFireButton()
    {
        if(state != BattleState.PLAYERTURN)
            return;
        //StartCoroutine(PlayerSkill());
        PlayerSkill();
        Skill.SetActive(false);
        Time.timeScale = 1f;
    }

    void PlayerSkill()
    {
        bool isDead = enemyUnit.TakeSkill(playerUnit.damage);
       
        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogueText.text = "The attack is successful!";

        //yield return new WaitForSeconds(1f); 

        if(isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            //StartCoroutine(EnemyTurn());
            EnemyTurn();
        }
    }

    void PlayerHeal()
    {
        playerUnit.Heal(20);

        playerHUD.SetHP(playerUnit.currentHP);
        dialogueText.text = "You feel refreshed";

        //yield return new WaitForSeconds(1f);

        state = BattleState.ENEMYTURN;
        //StartCoroutine(EnemyTurn());
        EnemyTurn();
    }

    public void onHealButton()
    {
        if(state != BattleState.PLAYERTURN)
            return;
        Skill.SetActive(false);
        Time.timeScale = 1f;
        //StartCoroutine(PlayerHeal());
        PlayerHeal();
    }

    public void onEndTurnButton()
    {
        if(state != BattleState.PLAYERTURN)
            return;
        state = BattleState.ENEMYTURN;
        //StartCoroutine(EnemyTurn());
        EnemyTurn();
    }


}
