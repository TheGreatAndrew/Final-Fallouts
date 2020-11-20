using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    
    public int health = 100;
    public int armor = 0;
    public int defense = 5;
    public int attack = 1;
    public int weaponDmg = 0;
    public int numArms = 2;

    public Dictionary<string, int> playerInfo; //see GetCurrentPlayerData() for explanation

    public string sceneName;
    public Vector3 currentPos;
    
    [SerializeField] private GameObject headGear;
    [SerializeField] private GameObject chestGear;
    [SerializeField] private GameObject armGear;
    [SerializeField] private GameObject feetGear;

    [SerializeField] private int headProtection;
    [SerializeField] private int chestProtection;
    [SerializeField] private int armProtection;
    [SerializeField] private int feetProtectionr;

    private Transform pos;

    // private Inventory inventory;
    [SerializeField] private InventoryUI inventoryUI;
    private Inventory inventory;
    public Text healthText;
    public Text armorText;
    public Text defenseText;
    public Text attackText;
    public Text weaponDmgText;
    public Text numArmsText;
    

    //Singleton pattern to access the player information from
    //other scenes
    void Start() 
    {
        DontDestroyOnLoad(this.gameObject);
        pos = gameObject.GetComponent<Transform>();
        sceneName = SceneManager.GetActiveScene().name;
        headProtection = headGear.GetComponent<GearInfo>().armor;
        chestProtection = chestGear.GetComponent<GearInfo>().armor;
        armProtection = armGear.GetComponent<GearInfo>().armor;
        feetProtectionr = feetGear.GetComponent<GearInfo>().armor;

        // armor = + headProtection + chestProtection + armProtection + feetProtectionr;
        armor = 0;
        weaponDmg = 0;
        playerInfo = new Dictionary<string, int>
        {
            {"Health", health},
            {"Armor", armor},
            {"Defense", defense},
            {"Attack", attack},
            {"WeaponDmg", weaponDmg},
            {"NumArms", numArms}
        }; //Needed to preserve player info across scenes
        
        inventory = Inventory.instance;
        // inventory = new Inventory();
        // inventoryUI.SetInventory(inventory);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        GetCurrentPlayerData();

        healthText.text = "Health: " + health;
        armorText.text = "Armor: " + armor;
        defenseText.text = "Defense: " + defense;
        attackText.text = "Attack: " + attack;
        weaponDmgText.text = "Weapon: " + weaponDmg;
        numArmsText.text = "numArms: " + numArms;

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
        headProtection = headGear.GetComponent<GearInfo>().armor;
        armor = headProtection + chestProtection + armProtection + feetProtectionr;
    }
    public void ChangeChestGear(GameObject newCG)
    {
        chestGear = newCG;
        chestProtection = chestGear.GetComponent<GearInfo>().armor;
        armor = headProtection + chestProtection + armProtection + feetProtectionr;
    }
    public void ChangeArmGear(GameObject newAG)
    {
        armGear = newAG;
        armProtection = armGear.GetComponent<GearInfo>().armor;
        armor = headProtection + chestProtection + armProtection + feetProtectionr;
    }
    public void ChangeFeetGear(GameObject newFG)
    {
        feetGear = newFG;
        feetProtectionr = feetGear.GetComponent<GearInfo>().armor;
        armor = headProtection + chestProtection + armProtection + feetProtectionr;
    }


    //Initiate Death Sequence
    private void Death()
    {
        Debug.Log("Player has died");
        //TODO Death Animation 
        //TODO Pull up Game Over Screen
        //TODO Play GameOver Music

    }

    public void GetCurrentPlayerData()
    {
        //Returns updates player data in the form of a dictionary
        //this might be needed in the future but if not it should be easy to remove all this
        //if this is removed dont forget to update battledata.cs and healthbar.cs
        playerInfo["Health"] = health;
        playerInfo["Armor"] = armor;
        playerInfo["Defense"] = defense;
        playerInfo["Attack"] = attack;
        playerInfo["WeaponDmg"] = weaponDmg;
        playerInfo["NumArms"] = numArms;
    }

    private void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
 
    private void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name.CompareTo("SimpleBattle") != 0)
        {
            sceneName = scene.name;
        }
        else
        {
            currentPos = pos.position;
        }
    }

}
