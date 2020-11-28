using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//TODO add extra items in shop after you buy original ones

//holds what's in the merchant's shop
//and displays the item currently being looked at
public class MerchantItems : MonoBehaviour
{
    //merchant menu;
    public int potionCost = 25;
    public Sprite potion;

    public int headGearCost = 100;
    public Sprite headGear;

    public int armGearCost = 125;
    public Sprite armGear;

    public int legGearCost = 125;
    public Sprite legGear;

    public int chestGearCost = 200;
    public Sprite chestGear;

    [SerializeField] Image setPotionImg;
    [SerializeField] Image setChestImg;
    [SerializeField] Image setHeadImg;
    [SerializeField] Image setArmImg;
    [SerializeField] Image setLegImg;
    
    [SerializeField] Image displayImage;
    [SerializeField] TextMeshProUGUI displayText;
    [SerializeField] TextMeshProUGUI CancelButtonText;

    [SerializeField] Inventory player;

    private void Start()
    {
        GameObject pl = GameObject.FindGameObjectWithTag("Player");
        player = pl.transform.GetChild(5).gameObject.transform.GetChild(0).gameObject.GetComponent<Inventory>();
        setPotionImg.sprite = potion;
        setHeadImg.sprite = headGear;
        setChestImg.sprite = chestGear;
        setArmImg.sprite = armGear;
        setLegImg.sprite = legGear;
    }

    public void displayPotion()
    {
        displayImage.sprite = potion;
        displayText.text = "$" + potionCost;
        CancelButtonText.text = "Cancel";
    }
    public void displayHead()
    {
        displayImage.sprite = headGear;
        displayText.text = "$" + headGearCost;
        CancelButtonText.text = "Cancel";
    }
    public void displayChest()
    {
        displayImage.sprite = chestGear;
        displayText.text = "$" + chestGearCost;
        CancelButtonText.text = "Cancel";
    }
    public void displayArms()
    {
        displayImage.sprite = armGear;
        displayText.text = "$" + armGearCost;
        CancelButtonText.text = "Cancel";
    }
    public void displayLegs()
    {
        displayImage.sprite = legGear;
        displayText.text = "$" + legGearCost;
        CancelButtonText.text = "Cancel";
    }
    public void displayNothing()
    {
        displayImage.sprite = null;
        displayText.text = "";
        CancelButtonText.text = "Leave";
    }

    public void createPotion()
    {
        Consumable potionItem = new Consumable();
        potionItem.name = "potion";
        potionItem.icon = potion;
        potionItem.healthEffect = 50;
        player.Add(potionItem);
    }

    public void createHead()
    {
        Equipment headGearItem = ScriptableObject.CreateInstance<Equipment>();
        headGearItem.name = "Iron Helmet";
        headGearItem.icon = headGear;
        headGearItem.equipSlot = EquipmentSlot.Head;
        headGearItem.armorModifier = 5;
        player.Add(headGearItem);
    }

    public void createChest()
    {
        Equipment chestGearItem = ScriptableObject.CreateInstance<Equipment>();
        chestGearItem.name = "Iron Chestplate";
        chestGearItem.icon = chestGear;
        chestGearItem.equipSlot = EquipmentSlot.Chest;
        chestGearItem.armorModifier = 10;
        player.Add(chestGearItem);
    }

    public void createArm()
    {
        Equipment armGearItem = ScriptableObject.CreateInstance<Equipment>();
        armGearItem.name = "Iron Gauntlets";
        armGearItem.icon = armGear;
        armGearItem.equipSlot = EquipmentSlot.SubWeapon;
        armGearItem.armorModifier = 5;
        player.Add(armGearItem);
    }

    public void createLeg()
    {
        Equipment legGearItem = ScriptableObject.CreateInstance<Equipment>();
        legGearItem.name = "Iron Boots";
        legGearItem.icon = legGear;
        legGearItem.equipSlot = EquipmentSlot.Feet;
        legGearItem.armorModifier = 5;
        player.Add(legGearItem);
    }


}
