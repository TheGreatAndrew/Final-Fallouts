using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * TODO: IMPLEMENT SAVE FILE
 */
public class BattleData : MonoBehaviour
{
    public HealthBar playerHealthBar;
    public HealthBar enemyHealthBar;
    private Dictionary<string,int> player;
    private Dictionary<string,int> enemy;
    private bool playerTurn = true;
    private bool enemyTurnRunning = false;

    public Button attackButton;
    public Button fleeButton;

    private PlayerInfo currentPlayerState;
    // Start is called before the first frame update
    void Start()
    {
        enemy = new Dictionary<string, int>
        {
            {"Health",50},
            {"Attack",20}
            
        };//more debug stuff
        GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().StopPlayer();
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = false;
        currentPlayerState = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>();
        player = currentPlayerState.playerInfo;
        playerHealthBar.SetMaxHealth(player["Health"]);
        enemyHealthBar.SetMaxHealth(enemy["Health"]);
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthBar.UpdateHealth(player["Health"]);
        enemyHealthBar.UpdateHealth(enemy["Health"]);
        if (currentPlayerState.health <= 0)
        {
            Flee();
            Debug.Log("Lost Battle");
            return;
        }

        if (enemy["Health"] <= 0)
        {
            Flee();
            Debug.Log("Won battle");

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
        currentPlayerState.health = 100;
        GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().enabled = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = true;
        Vector3 tempPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position = currentPlayerState.currentPos;
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
            currentPlayerState.health -= enemy["Attack"];
        }
        else
        {
            enemy["Health"] -= currentPlayerState.attack;
            playerTurn = false;
        }
    }
}
