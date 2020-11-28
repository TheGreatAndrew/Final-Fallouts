using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class EnemyGenerator : MonoBehaviour
{
    public MonsterClass currentMonster;
    private GameObject monsterPrefab;
    public PlayerInfo player;
    public PlayerMovement movement;
    public List<GameObject> monsters;
    private Random rng;
    private bool cooldownOff = true;
    private void Start()
    {
        rng = new Random();
        player = GetComponent<PlayerInfo>();
        movement = GetComponent<PlayerMovement>();
        monsterPrefab = Instantiate(monsters[7]);
    }

    private void FixedUpdate()
    {
        if (cooldownOff)
        {
            cooldownOff = false;
            ReplaceMonster();
            StartCoroutine(CoolDown());
        }
            
        player.currentMonster = currentMonster;
    }

    public void ReplaceMonster()
    {
        if (player.inBattle)
        {
            return;
        }
        var randomNumber = rng.Next(100);
        Destroy(monsterPrefab);
        switch (movement.biomeTag)
        {
            case "Overworld":
                monsterPrefab = Instantiate(randomNumber < 70 ? monsters[0] : monsters[1]); //gecko vs shroom
                break;
            case "HillTop":
                monsterPrefab = Instantiate(randomNumber < 70 ? monsters[1] : monsters[0]);//shroom vs gecko
                break;
            case "DungeonAbove":
                monsterPrefab = Instantiate(randomNumber < 50 ? monsters[2] : monsters[3]);//jelly vs slime
                break;
            case "DungeonBelow":
                monsterPrefab = Instantiate(randomNumber < 50 ? monsters[4] : monsters[5]);//shield vs sword
                break;
            case "QuestBoss":
                monsterPrefab = Instantiate(monsters[7]); //captain killer
                break;
            default:
                monsterPrefab = Instantiate(monsters[6]); //debug dragon
                Debug.Log("You are not supposed to see a dragon");
                break;
        }

        currentMonster = monsterPrefab.GetComponent<MonsterClass>();
        monsterPrefab.SetActive(false);
    }

    private IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(2);
        cooldownOff = true;
    }
    
}
