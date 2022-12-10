using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    
    public Text nameText;
    public Text levelText;
    public Slider hpSlider;
    public Slider mpSlider;
    public Image elements;

    public void SetHUD(Unit unit)
    {
        nameText.text = unit.unitName;
        levelText.text =  "Lvl " + unit.unitLevel;
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
        mpSlider.maxValue = unit.maxMP;
        mpSlider.value = unit.currentMP;

    }
    
    public void SetHP(int hp)
    {
        hpSlider.value = hp;
    }

    public void SetMP(int mp)
    {
        mpSlider.value = mp;
    }
}
