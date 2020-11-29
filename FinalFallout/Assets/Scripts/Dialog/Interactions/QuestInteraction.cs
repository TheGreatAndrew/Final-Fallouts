using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TODO: make a claim reward function and dialog
public class QuestInteraction : MonoBehaviour
{
    [SerializeField] QuestGiverList listOfQuests;

    private DialogManager dMang;
    private PlayerInfo player;
    [SerializeField] Animator questDisplay;

    private string QuestGiverName = "Hedy";

    public Dialog welcome;
    public Dialog questsAvailable;
    public Dialog noQuestsAvailable;
    public Dialog takeQuest;
    public Dialog refuseQuest;
    public Dialog leave;

    private string typeQuestLookingAt = "";


    private void Start()
    {
        dMang = FindObjectOfType<DialogManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>();
        //questDisplay = gameObject.GetComponent<Animator>();

        welcome = new Dialog();
        welcome.name = QuestGiverName;
        welcome.sentences = new string[1]
        {
            "Glad to see you're back safe and sound!"
        };

        questsAvailable = new Dialog();
        questsAvailable.name = QuestGiverName;
        questsAvailable.sentences = new string[1]
        {
            "Here's what I have for you"
        };

        noQuestsAvailable = new Dialog();
        noQuestsAvailable.name = QuestGiverName;
        noQuestsAvailable.sentences = new string[1]
        {
            "Sorry, maybe I'll have more quests next time"
        };

        takeQuest = new Dialog();
        takeQuest.name = QuestGiverName;
        takeQuest.sentences = new string[1]
        {
            "It's all yours. Good luck!"
        };

        refuseQuest = new Dialog();
        refuseQuest.name = QuestGiverName;
        refuseQuest.sentences = new string[1]
        {
            "No problem, don't overexert yourself kiddo"
        };

        leave = new Dialog();
        leave.name = QuestGiverName;
        leave.sentences = new string[1]
        {
            "Stay safe!"
        };
    }

    public void triggerInteraction()
    {
        questDisplay.SetBool("atQuestGiver", true);
        dMang.StartDialog(welcome);
        player.gameObject.GetComponent<PlayerMovement>().StopPlayer();
        player.gameObject.GetComponent<PlayerMovement>().enabled = false;
        StartCoroutine(waitSomeTime());
    }

    IEnumerator waitSomeTime()
    {
        yield return new WaitForSeconds(1.5f);

        if (listOfQuests.quests.Count > 0)
        {
            dMang.StartDialog(questsAvailable);
        }
        else
        {
            dMang.StartDialog(noQuestsAvailable);
            questDisplay.SetBool("atQuestGiver", false);
            player.gameObject.GetComponent<PlayerMovement>().enabled = true;
        }
    }

    public void lookEasyQuest()
    {
        typeQuestLookingAt = "easy";
        listOfQuests.changeDisplay(typeQuestLookingAt);
    }
    public void lookMediumQuest()
    {
        typeQuestLookingAt = "medium";
        listOfQuests.changeDisplay(typeQuestLookingAt);
    }
    public void lookHardQuest()
    {
        typeQuestLookingAt = "hard";
        listOfQuests.changeDisplay(typeQuestLookingAt);
    }
    public void lookBossQuest()
    {
        typeQuestLookingAt = "Boss";
        listOfQuests.changeDisplay(typeQuestLookingAt);
    }

    public void pushBuy()
    {
        dMang.StartDialog(takeQuest);
        listOfQuests.removeQuest(typeQuestLookingAt);

        listOfQuests.displayNothing();
        typeQuestLookingAt = "";
    }

    public void pushCancel()
    {
        if (typeQuestLookingAt != "")
        {
            dMang.StartDialog(refuseQuest);
            listOfQuests.displayNothing();
            typeQuestLookingAt = "";
        }
        else
        {
            dMang.StartDialog(leave);
            questDisplay.SetBool("atQuestGiver", false);
            player.gameObject.GetComponent<PlayerMovement>().enabled = true;
        }
    }

}
