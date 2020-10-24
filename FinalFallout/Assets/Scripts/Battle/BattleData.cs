using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleData : MonoBehaviour
{
    public HealthBar playerHealthBar;
    public HealthBar enemyHealthBar;
    private Dictionary<string,int> player;
    private Dictionary<string,int> enemy;

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
        StartCoroutine(ReturnToOverworld());
        StartCoroutine(DamagePlayer());
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthBar.UpdateHealth(player["Health"]);
        enemyHealthBar.UpdateHealth(enemy["Health"]);
    }

    private IEnumerator ReturnToOverworld()
    {
        //debug function
        yield return new WaitForSeconds(15f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().enabled = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = true;
        SceneManager.LoadScene("FirstLevel");
    }

    private IEnumerator DamagePlayer()
    {
        yield return new WaitForSeconds(5);
        currentPlayerState.health -= 25;
        enemy["Health"] -= 25;
    }
}
