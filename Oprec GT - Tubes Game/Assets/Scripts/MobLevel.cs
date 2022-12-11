using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MobLevel : MonoBehaviour
{
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
        Spawn();
    }

    public void Spawn()
    {
        touch = Random.Range(1, 5);
        if(touch == 1)
        {
            Level = Random.Range(1, 4);
            levelText.text = "Level " + Level;
            Mobname.text = "Slime";
            GetComponent<MobHealth>().increaseHealth(Level);
            GameObject enemyGo = Instantiate(enemyPrefab1, enemyBattleStation);
        }

        if(touch == 2)
        {
            Level = Random.Range(1, 4);
            levelText.text = "Level " + Level;
            Mobname.text = "Fairy";
            GetComponent<MobHealth>().increaseHealth(Level);
            GameObject enemyGo = Instantiate(enemyPrefab2, enemyBattleStation);
        }

        if(touch == 3)
        {
            Level = Random.Range(1, 4);
            levelText.text = "Level " + Level;
            Mobname.text = "Imp";
            GetComponent<MobHealth>().increaseHealth(Level);
            GameObject enemyGo = Instantiate(enemyPrefab3, enemyBattleStation);
        }

        if(touch == 4)
        {
            Level = Random.Range(1, 4);
            levelText.text = "Level " + Level;
            Mobname.text = "Skeleton Mage";
            GetComponent<MobHealth>().increaseHealth(Level);
            GameObject enemyGo = Instantiate(enemyPrefab4, enemyBattleStation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
