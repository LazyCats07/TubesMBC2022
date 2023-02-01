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
    public GameObject fireball;
    public GameObject Heall;
    

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
            //Collectables.instance.Addcoin();
            GameObject.Find("Audio_combat").GetComponent<AudioSource>().Stop();
            GameObject.Find("Audio_combatBoss").GetComponent<AudioSource>().Stop();
            GameObject.Find("Audio_Win").GetComponent<AudioSource>().Play();
            SetupBattle();
        }
        else if(state == BattleState.LOST)
        {
            GameOver.SetActive(true);
            Time.timeScale = 0f;
            GameObject.Find("Audio_combat").GetComponent<AudioSource>().Stop();
            GameObject.Find("Audio_combatBoss").GetComponent<AudioSource>().Stop();
            GameObject.Find("Audio_GameOver").GetComponent<AudioSource>().Play();
            SetupBattle();
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
        if(playerUnit.currentMP < 40)
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
        else if(playerUnit.currentMP >= 40)
            Fireballanim();
            PlayerSkill();
        Skill.SetActive(false);
        Time.timeScale = 1f;
    }

    void PlayerSkill()
    {
        bool isDead = enemyUnit.TakeSkill(playerUnit.damage);
        bool isMana = playerUnit.Mana(40);
        enemyHUD.SetHP(enemyUnit.currentHP);
        playerHUD.SetMP(playerUnit.currentMP);
        dialogueText.text = "The attack is successful!";

        //yield return new WaitForSeconds(1f); 

        if(isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else if(isMana)
        {
            state = BattleState.ENEMYTURN;
            //StartCoroutine(EnemyTurn());
            EnemyTurn();
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
       
        playerUnit.Heal(50);
        dialogueText.text = "You feel refreshed";
            
        playerHUD.SetHP(playerUnit.currentHP);
        playerHUD.SetMP(playerUnit.currentMP);
        

        //yield return new WaitForSeconds(1f);

        state = BattleState.ENEMYTURN;
        EnemyTurn();
        //StartCoroutine(EnemyTurn());
        
    }

    public void onHealButton()
    {   
        if(playerUnit.currentMP < 30)
        {   state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
        else if(playerUnit.currentMP >= 30)
            Healanim();
            PlayerHeal();
        
        if(state != BattleState.PLAYERTURN)
            return;
        Skill.SetActive(false);
        Time.timeScale = 1f;
        //StartCoroutine(PlayerHeal());
        
    }

    public void onEndTurnButton()
    {
        if(state != BattleState.PLAYERTURN)
            return;
        state = BattleState.ENEMYTURN;
        //StartCoroutine(EnemyTurn());
        EnemyTurn();
    }

    public void Fireballanim()
    {
        GameObject fb = (GameObject)Instantiate (fireball);
        
    }
    public void Healanim()
    {
        GameObject heal = (GameObject)Instantiate (Heall);
    }

}
