using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : MonoBehaviour
{
    public string enemyName;
    public int enemyLevel;

    public int damage;

    public int maxHP;
    public int currentHP;

    public bool takeDamage(int dmg)
    {
        currentHP -= dmg;

        if(currentHP <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Heal(int amount)
    {
        currentHP += amount;
        if(currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }

}
