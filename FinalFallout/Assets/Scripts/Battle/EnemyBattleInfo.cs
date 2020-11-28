using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattleInfo : MonoBehaviour
{
    public int health = 150;
    public int attack = 10;
    public int defense = 15;
    public int numArms = 2;
    public float chanceForAttack2 = 0.2f;

    private PlayerInfo player;
    private MonsterClass monster;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>();
    }

    private void Update()
    {
        //is this the best place to put it? I like calling it when player is attacking
        if (health <= 0)
        {
            Death();
        }
    }

    //simple slash attack
    public void attack1()
    {
        Debug.Log("Attack1");
        //TODO Animation

        //take out player health
        int attackPower = ((attack * numArms) + attack) - player.armor;
        if (attackPower < 0)
        {
            attackPower = 0;
        }
        player.health -= attackPower;

    }
    //double slash combo
    public void attack2()
    {
        Debug.Log("Attack2");
        //TODO Animation

        //take out player health
        int attackPower = (2 * (attack * numArms) + attack) - player.armor;
        if (attackPower < 0)
        {
            attackPower = 0;
        }
        player.health -= attackPower;

    }

    public void Death()
    {
        Debug.Log(gameObject.name + " has died");
        //TODO death animation
        //Are we only doing one enemy at a time? If so then win screen
        //if not then subtrack amount of enemies in battle simulator script
    }
}
