using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestMenu : MonoBehaviour
{
    //[SerializeField] GameObject[] displayRows;
    [SerializeField] Image[] displaySprites;
    [SerializeField] TextMeshProUGUI[] displayNameRewards;
    [SerializeField] TextMeshProUGUI[] displayLocation;
    [SerializeField] TextMeshProUGUI[] displayNumLeft;

    [SerializeField] Sprite defaultImg;

    private int firstFreeRow;
    private int maxQuests = 4;
    private string[] displayedQuests;

    void Start()
    {
        for(int ix = 0; ix < maxQuests; ix++)//hardcoding for now to only have 4 quests at a time
        {
            displaySprites[ix].sprite = defaultImg;
            displayNameRewards[ix].text = "";
            displayLocation[ix].text = "";
            displayNumLeft[ix].text = "";
        }
        firstFreeRow = 0;
    }

    public void displayQuest(Quest q)
    {
        if(firstFreeRow < maxQuests)
        {
            displaySprites[firstFreeRow].sprite = q.img;
            displayNameRewards[firstFreeRow].text = "Name: " + q.name + "\nReward: " + q.reward + " gold";
            displayLocation[firstFreeRow].text = "Location: " + q.location;
            displayNumLeft[firstFreeRow].text = "Number Left: " + q.numEnemies;
        }
        firstFreeRow++;
    }

    public void removeQuest(Quest q) 
    {
        for(int ix = 0; ix < maxQuests; ix++)
        {
            if(q.img == displaySprites[ix].sprite)
            {
                displayNameRewards[ix].text = "";
                displayLocation[ix].text = "";
                displayNumLeft[ix].text = "";
                displaySprites[ix].sprite = defaultImg;
                break;
            }
        }
    }

}
