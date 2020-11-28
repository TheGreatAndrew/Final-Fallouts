using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = System.Random;

/*
 * TODO: IMPLEMENT SAVE FILE
 */
public class BattleData : MonoBehaviour
{
    public HealthBar playerHealthBar;
    public HealthBar enemyHealthBar;
    private bool playerTurn = true;
    private bool enemyTurnRunning = false;
    private Random rng;
    private int maxHp;
    public Button attackButton;
    public Button fleeButton;

    private PlayerInfo currentPlayerState;

    private EnemyBattleInfo currentEnemyState;
    // Start is called before the first frame update
    void Start()
    {
        currentEnemyState = FindObjectOfType<EnemyBattleInfo>();
        GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().StopPlayer();
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = false;
        currentPlayerState = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>();
        playerHealthBar.SetMaxHealth(currentPlayerState.health);
        maxHp = currentPlayerState.health;
        enemyHealthBar.SetMaxHealth(currentEnemyState.health);
        rng = new Random();
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthBar.UpdateHealth(currentPlayerState.health);
        enemyHealthBar.UpdateHealth(currentEnemyState.health);
        if (currentPlayerState.health <= 0)
        {
            Flee();
            Debug.Log("Lost Battle");
            return;
        }

        if (currentEnemyState.health <= 0)
        {
            currentEnemyState.Death();
            Flee();
            Debug.Log("Won battle");
            PlayerPrefs.SetInt("BattleWon", 1);

            return;
        }

        if (!playerTurn)
        {
            attackButton.interactable = false;
            fleeButton.interactable = false;
            if (!enemyTurnRunning)
            {
                StartCoroutine(EnemyTurn());
            }
        }
        else
        {
            attackButton.interactable = true;
            fleeButton.interactable = true;
        }
    }
    
    private IEnumerator EnemyTurn()
    {
        playerTurn = false;
        enemyTurnRunning = true;
        yield return new WaitForSeconds(5);
        Attack();
        playerTurn = true;
        enemyTurnRunning = false;
    }

    public void Flee()
    {
        Debug.Log("Flee Called");
        currentPlayerState.health = maxHp;
        GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().enabled = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = true;
        Vector3 tempPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position = currentPlayerState.currentPos;
        PlayerPrefs.SetInt("BattleScene", 1);
        SceneManager.LoadScene(currentPlayerState.sceneName);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position = tempPos;
        
        // TODO : if won, random rewards
        // var playerPos = currentPlayerState.GetComponent<PlayerInfo>().transform.position;
        // var equipment = Resources.Load("Equipments/" + "Sworda");
        // Instantiate(equipment, playerPos + new Vector3(1, 0, 0), Quaternion.identity);

    }

    public void Attack()
    {
        Debug.Log("Attack called");
        if (!playerTurn)
        {
            currentEnemyState.attack1();
            if (rng.Next(100) < 100 * .1f * currentEnemyState.numArms)
            {
                currentEnemyState.attack2();
            } 
        }
        else
        {
            var tmp = currentPlayerState.attack - currentEnemyState.defense;
            currentEnemyState.health -= (tmp>0)? tmp:1;
            if (rng.Next(100) < 100 * .1f * currentPlayerState.numArms)
            {
                currentEnemyState.health -= (tmp>0)? tmp/2:0;
            }
            playerTurn = false;
        }
    }
}
