using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int unitLevel;
    public int maxMP;
    public int currentMP;

    public int damage;

    public int maxHP;
    public int currentHP;

    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;

        if(currentHP <= 0)
            return true;
        else
            return false;
    }

    public bool TakeSkill(int dmg)
    {
        currentHP -= (dmg + 10 );
        if(currentHP <= 0)
            return true;
        // else if(currentHP > 0)
        //     return false;
        // else if(currentMP > 0)
        //     return false;
        // else if(currentMP <= 0)
        //     return false;
        else 
            return false;
    }

    public bool Mana(int mana)
    {
        currentMP -= mana;
        if(currentMP > 0)
            return true;
        else
            return false;
    }

    public void Heal(int amount)
    {
        currentMP -= 30;
        currentHP += amount;
        if(currentHP > maxHP)
            currentHP = maxHP;
    }
}
