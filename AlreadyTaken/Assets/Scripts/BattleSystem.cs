using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }
public class BattleSystem : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;

    public Transform playerBS;
    public Transform enemyBS;

    EnemyUnit playerUnit;
    EnemyUnit enemyUnit;

    public Text dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;
    

    public BattleState state;
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(player, playerBS);
        playerUnit = playerGO.GetComponent<EnemyUnit>();

        GameObject enemyGO = Instantiate(enemy, enemyBS);
        enemyUnit = enemyGO.GetComponent<EnemyUnit>();

        dialogueText.text = "You've been attack by " + enemyUnit.enemyName + "!";
        playerHUD.setHUD(playerUnit);
        enemyHUD.setHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        playerTurn();
    }

    void playerTurn()
    {
        dialogueText.text = "It's your turn!";
    }

    void EndBattle()
    {
        if(state == BattleState.WON)
        {
            exit();
        }else if(state == BattleState.LOST)
        {
            exit();
        }
    }

    IEnumerator EnemyTurn()
    {
        dialogueText.text = enemyUnit.enemyName + " attacks!";

        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.takeDamage(enemyUnit.damage);

        playerHUD.setHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            state = BattleState.LOST;
            dialogueText.text = "You've lost! Press ESC to proceed.";
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Escape));
            EndBattle();
            
        }
        else
        {
            state = BattleState.PLAYERTURN;
            playerTurn();
        }

    }

    IEnumerator PlayerHeal()
    {
        state = BattleState.ENEMYTURN;
        int healed = Random.Range(1, 8);
        playerUnit.Heal(healed);
        playerHUD.setHP(playerUnit.currentHP);
        dialogueText.text = "You've healed yourself for " + healed + " HP!";

        yield return new WaitForSeconds(2f);
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator PlayerAttack()
    {
        state = BattleState.ENEMYTURN;
        dialogueText.text = "Successful hit!";

        bool isDead = enemyUnit.takeDamage(playerUnit.damage);

        enemyHUD.setHP(enemyUnit.currentHP);

        if (isDead)
        {
            state = BattleState.WON;
            dialogueText.text = "You've won! Press ESC to proceed.";
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Escape));
            EndBattle();

        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
        yield return new WaitForSeconds(2f);
    }


    public void onAttackButton()
    {
        if(state != BattleState.PLAYERTURN)
        {
            return;
        }
        StartCoroutine(PlayerAttack());
    }
    public void onHealButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }
        StartCoroutine(PlayerHeal());
    }


    public Animator transition;
    public float transitionTime = 1f;

    public void exit()
    {
        StartCoroutine(LoadLevel(1));
    }

    IEnumerator LoadLevel(int LevelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(LevelIndex);
    }
}
