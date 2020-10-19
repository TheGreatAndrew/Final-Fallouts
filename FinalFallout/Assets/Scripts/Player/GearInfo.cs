using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearInfo : MonoBehaviour
{
    public int armor;
    public int cost;
    public int durabililty;

    public GearInfo(int armorData, int costData, int durData)
    {
        armor = armorData;
        cost = costData;
        durabililty = durData;
    }
}
