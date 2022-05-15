using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text nameText;
    public Text levelText;
    public Text maxHP;
    public Text currentHP;
    public Slider hpSlider;

    public void setHUD(EnemyUnit unit)
    {
        nameText.text = unit.enemyName;
        levelText.text = "Lv " + unit.enemyLevel;
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
        maxHP.text = "" + unit.maxHP;
        currentHP.text = "" + unit.currentHP;
    }

    public void setHP(int hp)
    {
        hpSlider.value = hp;
        currentHP.text = "" + hp;
    }

}
