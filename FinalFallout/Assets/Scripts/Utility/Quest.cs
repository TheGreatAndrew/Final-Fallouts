﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : ScriptableObject
{
    public new string name;
    public string description;
    public MonsterClass enemy;
    public int numEnemies;
    public int reward;
    public string location;
    public Sprite img;

}
