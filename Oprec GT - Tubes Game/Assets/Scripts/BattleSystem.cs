using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST, END }

// public class BattleSystem : MonoBehaviour
// {

//     public GameObject playerPrefab;
//     public GameObject enemyPrefab;

    
//     public GameObject GameOver;
//     public GameObject Win;

//     public Transform playerBattleStation;
//     public Transform enemyBattleStation;

//     PlayerHealth playerUnit;
//     Unit enemyUnit;

//     public Text dialogueText;

//     public BattleHUD playerHUD;
//     public BattleHUD enemyHUD;

//     public BattleState state;
    

//     // Start is called before the first frame update
//     void Start()
//     {
//         state = BattleState.START;
//         GetComponent<LevelSystem>().GetExpSaved();
//         SetupBattle();
       
//     }


//     void SetupBattle()
//     {
//         state = BattleState.PLAYERTURN;
//         PlayerTurn();

//         //GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
//         playerUnit = GetComponent<PlayerHealth>().giveDamage(20);

//         GameObject enemyGo =  Instantiate(enemyPrefab, enemyBattleStation);
//         enemyUnit = enemyGo.GetComponent<Unit>();

//         //dialogueText.text = "An Evil " + enemyUnit.unitName + " Approaches...";

//         //playerHUD.SetHUD(playerUnit);
//         enemyHUD.SetHUD(enemyUnit);


//     }

//     void PlayerAttack()
//     {
//         bool isDead = enemyUnit.TakeDamage(playerUnit.giveDamage);

//         enemyHUD.SetHP(enemyUnit.currentHP);
//         dialogueText.text = "The attack is successful!";

//         //yield return new WaitForSeconds(0f);

//         if(isDead)
//         {
//             state = BattleState.WON;
//             EndBattle();
//         }
//         else
//         {
//             state = BattleState.ENEMYTURN;
//             StartCoroutine(EnemyTurn());
        
//         }
//     }

//     IEnumerator EnemyTurn()
//     {
//         dialogueText.text = enemyUnit.unitName + " attacks!";

//         yield return new WaitForSeconds(1f);

//         bool isDead = playerUnit.TakeDamage(enemyUnit.damage);   

//         //playerHUD.SetHP(playerUnit.health);

//         yield return new WaitForSeconds(1f);

//         if(isDead)
//         {
//             state = BattleState.LOST;
//             EndBattle();
//         }
//         else
//         {
//             state = BattleState.PLAYERTURN;
//             PlayerTurn();
//         }
//     }

//     void EndBattle()
//     {
//         if(state == BattleState.WON)
//         {
//             win();
//         }
//         else if(state == BattleState.LOST)
//         {
//             end();
//         }
//     }

//     void PlayerTurn()
//     {
//         dialogueText.text = "Choose an action:";
//         if(state != BattleState.PLAYERTURN)
//             state = BattleState.PLAYERTURN;
        
        
//     }

//     // IEnumerator PlayerHeal()
//     // {
//     //     playerUnit.Heal(5);

//     //     playerHUD.SetHP(playerUnit.currentHP);
//     //     dialogueText.text = "You feel better";

//     //     yield return new WaitForSeconds(1f);

//     //     state = BattleState.ENEMYTURN;
//     //     StartCoroutine(EnemyTurn());
        
//     // }

//     public void OnAttackButton()
//     {
//         if(state != BattleState.PLAYERTURN)
//             return;

//         //StartCoroutine(PlayerAttack());
//         PlayerAttack();
//     }

//     public void OnEndButton()
//     {
//         if(state != BattleState.PLAYERTURN)
//             return;
        
//         StartCoroutine(EnemyTurn());
//     }

//     public void OnHealButton()
//     {
//         if(state != BattleState.PLAYERTURN)
//             return;

//         StartCoroutine(PlayerHeal());
        
//     }

//     public void end()
//     {
//         GameOver.SetActive(true);
//         Time.timeScale = 0f;
//         GetComponent<LevelSystem>().ResetLevel();
//     }

//     public void win()
//     {
//         Win.SetActive(true);
//         Time.timeScale = 0f;
//         bool isDead = enemyUnit.TakeDamage(playerUnit.giveDamage);
//         if(isDead)
//             GetComponent<LevelSystem>().GainExperienceFlatRate(20);
            
            
            // if(state != BattleState.WON)
            //     ResumeScene2();
            
        
            
//     }

//     public void Title()
//     {
//         SceneManager.LoadScene("Main Menu");
//     }
    
//     public void ResumeScene4()
//     {
//         SceneManager.LoadScene("Area4_Roaming");
//     }

//     public void ResumeScene1()
//     {
//         SceneManager.LoadScene("Tutorial_Roaming");
//     }

//     public void ResumeScene2()
//     {
//         SceneManager.LoadScene("Area2_Roaming");
//     }


//     public void Next()
//     {
//         SceneManager.LoadScene("ED_Cutscene");
//     }
// }
