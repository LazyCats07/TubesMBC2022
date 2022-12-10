using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int unitLevel;

    public int damage;

    public int maxHP;
    public int currentHP;

    public int maxMP;
    public int currentMP;

    // public bool TakeDamage(int damage)
    // {
    //     currentHP -= damage;

    //     if(currentHP <= 0)
    //         return true;
    // }

    public void Heal(int amount)
    {
        currentHP += amount;
        if(currentHP > maxHP)
            currentHP = maxHP;
    }
}
