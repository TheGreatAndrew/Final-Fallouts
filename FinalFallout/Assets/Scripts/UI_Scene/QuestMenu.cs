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

    private void Awake()
    {
        displayedQuests = new string[4];

        for (int ix = 0; ix < maxQuests; ix++)//hardcoding for now to only have 4 quests at a time
        {
            displaySprites[ix].sprite = defaultImg;
            displayNameRewards[ix].text = "";
            displayLocation[ix].text = "";
            displayNumLeft[ix].text = "";
        }

        firstFreeRow = 0;
    }

    public void setQuest(Quest q)
    {
        Debug.Log("Quest is: " + q.name);
        
        if (firstFreeRow < maxQuests)
        {
            displaySprites[firstFreeRow].sprite = q.img;
            displayNameRewards[firstFreeRow].text = q.name + "\nReward: " + q.reward + " gold";
            displayLocation[firstFreeRow].text = "Location: " + q.location;
            displayNumLeft[firstFreeRow].text = "Number Left: " + q.numEnemies;
            displayedQuests[firstFreeRow] = q.name;
        }
        firstFreeRow++;
    }

    public void removeQuest(Quest q)
    {
        for (int ix = 0; ix < maxQuests; ix++)
        {
            if (q.img == displaySprites[ix].sprite)
            {
                displayNameRewards[ix].text = "";
                displayLocation[ix].text = "";
                displayNumLeft[ix].text = "";
                displaySprites[ix].sprite = defaultImg;
                break;
            }
        }
    }

    public void displayQuests(List<Quest> qs)
    {
        if (firstFreeRow == 0)
        {
            foreach (Quest q in qs)
            {
                setQuest(q);
            }
        }
    }

    public void updateDisplay(Quest q)
    {

        for(int ix = 0; ix < maxQuests; ix++)
        {
            if(displayedQuests[ix] != null && q.name == displayedQuests[ix])
            {
                displayNumLeft[ix].text = "Number Left: " + q.numEnemies;
            }
        }
    }

}
