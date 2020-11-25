using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterEnum : MonoBehaviour
{
    private void Start()
    {
        
    }

    /*
    * This script contains information for the monstertypes, please use the monstertypes enum when you are calling the
     * enemy generator or doing anything in regards to instantiating monsters
     *
     * feel free to add members as you see fit, but when you add members in, please have a sprite associated with it
     * otherwise i will just use a placeholder
    */
}

public enum MonsterType
{
    Slime,
    Mushroom,
    Gecko,
    Skeleton,
    Jelly,
    Boss
}
