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

    private void Start()
    {
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

}
