using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterClass : MonoBehaviour
{
    [SerializeField] SpriteRenderer displayMonster; //image attached to gameobject

    public Sprite monsterSprite;
    public string name;
    public int health;
    public int attack;
    public int defense;
    public int rewards;
    public int numArms;
    public float chanceAttack2;
    public string location;



}
