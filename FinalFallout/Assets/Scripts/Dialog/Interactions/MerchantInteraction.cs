using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: update inventory
public class MerchantInteraction : MonoBehaviour
{
    DialogManager dMang;
    PlayerInfo player;
    Animator merchantDisplay;


    Dialog welcome;
    Dialog cancel;
    Dialog noMoney;

    Dialog BuyPotion;
    Dialog PotionYes;
    Dialog PotionNo;

    Dialog BuyHeadGear;
    Dialog BuyChestGear;
    Dialog BuyArmGear;
    Dialog BuyLegGear;

    Dialog GearYes;
    Dialog GearNo;

    [SerializeField] MerchantItems shopItems;

    private string merchantName = "Mr. Babbage";
    private string gearLookingAt = "";


    private void Start()
    {
        
        dMang = FindObjectOfType<DialogManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>();
        merchantDisplay = gameObject.GetComponent<Animator>();

        welcome = new Dialog();
        welcome.name = merchantName;
        welcome.sentences = new string[1]
        {
            "Welcome! I sell potions and gear to keep all safe who journey past our humble town!"
        };

        BuyPotion = new Dialog();
        BuyPotion.name = merchantName;
        BuyPotion.sentences = new string[2]
        {
            "Ah what adventurer would you be without a health potion! A dead one.",
            "That's " + shopItems.potionCost + " gold a piece!"
        };

        BuyHeadGear = new Dialog();
        BuyHeadGear.name = merchantName;
        BuyHeadGear.sentences = new string[2]
        {
            "What's the most important part of your body? Your head! Protect it!",
            "That'll be " + shopItems.headGearCost + "gold please"
        };

        BuyChestGear = new Dialog();
        BuyChestGear.name = merchantName;
        BuyChestGear.sentences = new string[2]
        {
            "This here beauty will protect all your organs!",
            "For the fair price of " + shopItems.chestGearCost + " gold"
        };

        BuyArmGear = new Dialog();
        BuyArmGear.name = merchantName;
        BuyArmGear.sentences = new string[2]
        {
            "Gotta keep your hands protected otherwise you can't do max damage amirite?",
            "Only " + shopItems.armGearCost + " gold to keep them intact"
        };

        BuyLegGear = new Dialog();
        BuyLegGear.name = merchantName;
        BuyLegGear.sentences = new string[2]
        {
            "Trust me, you don't want the fee of me coming to find you after some monster ate your legs",
            "For just " + shopItems.legGearCost + " gold pieces you'll save in the long run!"
        };

        cancel = new Dialog();
        cancel.name = merchantName;
        cancel.sentences = new string[1]
        {
            "Safe Travels! Make sure to stop by anytime you need supplies"
        };

        PotionYes = new Dialog();
        PotionYes.name = merchantName;
        PotionYes.sentences = new string[1]
        {
            "Excellent choice! I like my customers to come back alive!"
        };

        PotionNo = new Dialog();
        PotionNo.name = merchantName;
        PotionNo.sentences = new string[1]
        {
            "Shame. Hope you make it back!"
        };

        GearYes = new Dialog();
        GearYes.name = merchantName;
        GearYes.sentences = new string[1]
        {
            "Great! Pleasure doing business with you!"

        };

        GearNo = new Dialog();
        GearNo.name = merchantName;
        GearNo.sentences = new string[1]
        {
            "Welp. Good luck out there…unprotected….alone….I'm sure you'll be fine kid"
        };

        noMoney = new Dialog();
        noMoney.name = merchantName;
        noMoney.sentences = new string[1]
        {
            "Woah there kiddo! The only worse thing worse than a picky adventurer is a broke one! Come back when you have more gold!"
        };
    }

    public void TriggerInteraction()
    {
        merchantDisplay.SetBool("atMerchant", true);
        dMang.StartDialog(welcome);
        player.gameObject.GetComponent<PlayerMovement>().StopPlayer();
        player.gameObject.GetComponent<PlayerMovement>().enabled = false;
    }

    public void LeaveShop()
    {
        dMang.StartDialog(cancel);
        merchantDisplay.SetBool("atMerchant", false);
        //stop movement
        player.gameObject.GetComponent<PlayerMovement>().enabled = true;
    }

    public void BuyButton()
    {
        switch(gearLookingAt)
        {
            case "potion":
                TriggerBuyPotion();
                break;
            case "head":                
            case "chest":
            case "arms":
            case "legs":
                TriggerBuyGear();
                break;
            case "":
                break;
        }
    }

    public void CancelButton()
    {
        switch (gearLookingAt)
        {
            case "potion":
                DontBuyPotion();
                break;
            case "head":
            case "chest":
            case "arms":
            case "legs":
                DontBuyGear();
                break;
            case "":
                LeaveShop();
                break;
        }
    }

    public void askBuyPotion()
    {
        gearLookingAt = "potion";
        dMang.StartDialog(BuyPotion);
        shopItems.displayPotion();
    }

    public void TriggerBuyPotion()
    {
        dMang.StartDialog(PotionYes);
        if (player.gold >= shopItems.legGearCost)
        {
            //update inventory for chest
            player.gold -= shopItems.legGearCost;
        }
        else
        {
            dMang.StartDialog(noMoney);
        }
        shopItems.displayNothing();
        gearLookingAt = "";
    }

    public void DontBuyPotion()
    {
        gearLookingAt = "";
        dMang.StartDialog(PotionNo);
        shopItems.displayNothing();
    }

    public void askBuyHeadGear()
    {
        gearLookingAt = "head";
        dMang.StartDialog(BuyHeadGear);
        shopItems.displayHead();
    }

    public void askBuyChestGear()
    {
        gearLookingAt = "chest";
        dMang.StartDialog(BuyChestGear);
        shopItems.displayChest();
    }

    public void askBuyArmGear()
    {
        gearLookingAt = "arms";
        dMang.StartDialog(BuyArmGear);
        shopItems.displayArms();
    }

    public void askBuyLegGear()
    {
        gearLookingAt = "legs";
        dMang.StartDialog(BuyLegGear);
        shopItems.displayLegs();
    }

    public void TriggerBuyGear()
    {
        dMang.StartDialog(GearYes);

        switch (gearLookingAt)
        {
            case "chest":
                if (player.gold >= shopItems.chestGearCost)
                {
                    //update inventory for chest
                    player.gold -= shopItems.chestGearCost;
                }
                else
                {
                    dMang.StartDialog(noMoney);
                }
                break;
            case "head":
                if (player.gold >= shopItems.headGearCost)
                {
                    //update inventory for chest
                    player.gold -= shopItems.headGearCost;
                }
                else
                {
                    dMang.StartDialog(noMoney);
                }
                break;
            case "arms":
                if (player.gold >= shopItems.armGearCost)
                {
                    //update inventory for chest
                    player.gold -= shopItems.armGearCost;
                }
                else
                {
                    dMang.StartDialog(noMoney);
                }
                break;
            case "legs":
                if (player.gold >= shopItems.legGearCost)
                {
                    //update inventory for chest
                    player.gold -= shopItems.legGearCost;
                }
                else
                {
                    dMang.StartDialog(noMoney);
                }
                break;
            case "":
                Debug.LogWarning("Woah how'd you get here in the MerchantInteraction Switch line?!");
                break;
        }
        shopItems.displayNothing();
        gearLookingAt = "";
    }

    public void DontBuyGear()
    {
        dMang.StartDialog(GearNo);
        shopItems.displayNothing();
        gearLookingAt = "";
    }

    /*
     * 
     * This section is to update the dialog to reflect any new prices in inventory to the gear
     * 
     */
    public void updateHeadGearDialog()
    {
        BuyHeadGear.sentences[1] = "That'll be " + shopItems.headGearCost + "gold please";
    }

    public void updateChestGearDialog()
    {
        BuyChestGear.sentences[1] = "For the fair price of " + shopItems.chestGearCost + " gold";
    }

    public void updateArmGearDialog()
    {
        BuyArmGear.sentences[1] = "Only " + shopItems.armGearCost + " gold to keep them intact";
    }

    public void updateLegGearDialog()
    {
        BuyLegGear.sentences[1] = "For just " + shopItems.legGearCost + " gold pieces you'll save in the long run!";
    }
}
