using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class QuestGiverList : MonoBehaviour
{
    public List<Quest> quests;
    private PlayerQuestList player;

    private int easyNum = 3;
    private int medNum = 3;
    private int hardNum = 3;
    private int boss = 1;

    //Overworld Quest Monsters
    private string easyMonster = "Slimes";
    private string medMonster = "Mushrooms";
    private string hardMonster = "Geckos";
    private string bossMonster = "Captain Killer";

    private int easyReward = 500;
    private int medReward = 1000;
    private int hardReward = 1500;
    private int bossReward = 2000;

    [SerializeField] Image displayImg;
    [SerializeField] TextMeshProUGUI displayText;
    [SerializeField] TextMeshProUGUI displayReward;
    [SerializeField] TextMeshProUGUI cancelText;


    [SerializeField] TextMeshProUGUI easyText;
    [SerializeField] TextMeshProUGUI medText;
    [SerializeField] TextMeshProUGUI hardText;
    [SerializeField] TextMeshProUGUI bossText;


    [SerializeField] Sprite easySprite;
    [SerializeField] Sprite medSprite;
    [SerializeField] Sprite hardSprite;
    [SerializeField] Sprite bossSprite;

    Quest easy;
    Quest medium;
    Quest hard;
    Quest Boss;

    [SerializeField] MonsterClass easyEnemy;
    [SerializeField] MonsterClass medEnemy;
    [SerializeField] MonsterClass hardEnemy;
    [SerializeField] MonsterClass bossEnemy;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerQuestList>();

        displayReward.text = "";
        displayText.text = "";
        easy = new Quest();
        easy.name = "1st " + easyMonster + " Quest";
        easy.description = "Mr. Dijkstra is having a hard time getting to his crops just outside of town. He wants you to thin out the "
            + easyMonster + " so he can get there faster.\nKill " + easyNum + " " + easyMonster + "!";
        easy.numEnemies = easyNum;
        easy.reward = easyReward;
        easy.location = "Overworld";
        easy.img = easySprite;
        easy.enemy = easyEnemy;
        quests.Add(easy);

        medium = new Quest();
        medium.name = "1st " + medMonster + " Quest";
        medium.description = "Mr. Boole is undecided if mushroom monsters are poisonous or not. For his experimentation please kill and bring back " + medNum + " " + medMonster;
        medium.numEnemies = medNum;
        medium.reward = medReward;
        medium.location = "Overworld: HillTops";
        medium.img = medSprite;
        medium.enemy = medEnemy;
        quests.Add(medium);

        hard = new Quest();
        hard.name = "1st " + hardMonster + " Quest";
        hard.description = "Mrs. Hopper thinks she can understand " + hardMonster +
            ". She thinks they're planning an attack and would like you to strike first.\nTake out " + hardNum + " " + hardMonster + " to help ease her mind";
        hard.numEnemies = hardNum;
        hard.reward = hardReward;
        hard.location = "Overworld: Around the Dungeon";
        hard.img = hardSprite;
        hard.enemy = hardEnemy;
        quests.Add(hard);

        Boss = new Quest();
        Boss.name = "Time to Shine! Boss Fight!";
        Boss.description = "This is a personal matter. This " + bossMonster + " has been stopping anyone from getting into the dragon's lair for a few weeks.\n" +
            "Two birds one stone with this quest.\n" + "Kill him and you'll be able to get into the dungeon to find your teacher.";
        Boss.numEnemies = 1;
        Boss.reward = bossReward;
        Boss.location = "Overworld: Dungeon entrance";
        Boss.img = bossSprite;
        Boss.enemy = bossEnemy;
        quests.Add(Boss);

        easyText.text = easy.name;
        medText.text = medium.name;
        hardText.text = hard.name;
        bossText.text = Boss.name;
        cancelText.text = "Leave";
    }

    public void changeDisplay(string type)
    {
        switch (type)
        {
            case "easy":
                displayImg.sprite = easySprite;
                displayText.text = easy.description;
                displayReward.text = "Reward: " + easy.reward + " gold";
                cancelText.text = "Cancel";
                break;
            case "medium":
                displayImg.sprite = medSprite;
                displayText.text = medium.description;
                displayReward.text = "Reward: " + medium.reward + " gold";
                cancelText.text = "Cancel";
                break;
            case "hard":
                displayImg.sprite = hardSprite;
                displayText.text = hard.description;
                displayReward.text = "Reward: " + hard.reward + " gold";
                cancelText.text = "Cancel";
                break;
            case "Boss":
                displayImg.sprite = bossSprite;
                displayText.text = Boss.description;
                displayReward.text = "Reward: " + Boss.reward + " gold";
                cancelText.text = "Cancel";
                break;
        }
    }

    public void displayNothing()
    {
        displayImg.sprite = null;
        displayText.text = "";
        displayReward.text = "";
        cancelText.text = "Leave";
    }

    public void removeQuest(string type)
    {
        switch (type)
        {
            case "easy":
                if (quests.Contains(easy))
                {
                    player.addQuest(easy);
                    quests.Remove(easy);
                    easyText.text = "";
                    easyText.transform.parent.GetComponent<Button>().enabled = false;
                }
                break;
            case "medium":
                if (quests.Contains(medium))
                {
                    player.addQuest(medium);
                    quests.Remove(medium);
                    medText.text = "";
                    medText.transform.parent.GetComponent<Button>().enabled = false;
                }
                break;
            case "hard":
                if (quests.Contains(hard))
                {
                    player.addQuest(hard);
                    quests.Remove(hard);
                    hardText.text = "";
                    hardText.transform.parent.GetComponent<Button>().enabled = false;
                }
                break;
            case "Boss":
                if (quests.Contains(Boss))
                {
                    player.addQuest(Boss);
                    quests.Remove(Boss);
                    bossText.text = "";
                    bossText.transform.parent.GetComponent<Button>().enabled = false;
                }
                break;
        }
    }

}

