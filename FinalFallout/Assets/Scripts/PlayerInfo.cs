using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public int health = 100;
    public int armor = 0;
    public int defense = 5;
    public int attack = 1;
    public int weaponDmg = 0;
    public int numArms = 2;


    [SerializeField] private GameObject headGear;
    [SerializeField] private GameObject chestGear;
    [SerializeField] private GameObject armGear;
    [SerializeField] private GameObject feetGear;

    [SerializeField] private int headProtectionr;
    [SerializeField] private int chestProtection;
    [SerializeField] private int armProtection;
    [SerializeField] private int feetProtectionr;

    // Start is called before the first frame update
    void Start() 
    {
        headProtectionr = headGear.GetComponent<GearInfo>().armor;
        chestProtection = chestGear.GetComponent<GearInfo>().armor;
        armProtection = armGear.GetComponent<GearInfo>().armor;
        feetProtectionr = feetGear.GetComponent<GearInfo>().armor;

        armor = headProtectionr + chestProtection + armProtection + feetProtectionr;
    }

    // Update is called once per frame
    void Update()
    {
        //check if dead
        if(health <= 0)
        {
            Death();
        }
    }
    /******************************************
     *      Change equipment functions
     *      TODO can change display from here?
     *****************************************/
    public void ChangeHeadGear(GameObject newHG)
    {
        headGear = newHG;
        headProtectionr = headGear.GetComponent<GearInfo>().armor;
        armor = headProtectionr + chestProtection + armProtection + feetProtectionr;
    }
    public void ChangeChestGear(GameObject newCG)
    {
        chestGear = newCG;
        chestProtection = chestGear.GetComponent<GearInfo>().armor;
        armor = headProtectionr + chestProtection + armProtection + feetProtectionr;
    }
    public void ChangeArmGear(GameObject newAG)
    {
        armGear = newAG;
        armProtection = armGear.GetComponent<GearInfo>().armor;
        armor = headProtectionr + chestProtection + armProtection + feetProtectionr;
    }
    public void ChangeFeetGear(GameObject newFG)
    {
        feetGear = newFG;
        feetProtectionr = feetGear.GetComponent<GearInfo>().armor;
        armor = headProtectionr + chestProtection + armProtection + feetProtectionr;
    }


    //Initiate Death Sequence
    private void Death()
    {
        Debug.Log("Player has died");
        //TODO Death Animation 
        //TODO Pull up Game Over Screen
        //TODO Play GameOver Music

    }
}
