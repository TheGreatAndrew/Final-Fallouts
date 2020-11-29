using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQuestList : MonoBehaviour
{
    public List<Quest> playerQuests;
    private List<Quest> toRemove;

    [SerializeField] QuestMenu questDisplay;

    private void Awake()
    {
        playerQuests = new List<Quest>();
        toRemove = new List<Quest>();

    }
    private void Start()
    {
        //questDisplay = GameObject.FindGameObjectWithTag("QuestMenu").GetComponent<QuestMenu>();
        GameObject pl = GameObject.FindGameObjectWithTag("Player");
        questDisplay = pl.transform.GetChild(5).gameObject.transform.GetChild(2).gameObject.GetComponent<QuestMenu>();

        if (playerQuests.Count > 0)
        {
            questDisplay.displayQuests(playerQuests);
        }
    }


    public void addQuest(Quest _quest)
    {
        playerQuests.Add(_quest);
        questDisplay.setQuest(_quest);

    }

    public void defeatEnemy(MonsterClass enemy)
    {
        
        foreach (Quest q in playerQuests)
        {
            
            if (enemy.monsterSprite == q.enemy.monsterSprite)
            {
                Debug.Log("Quest Enemy-- for: " + enemy.name);
                q.numEnemies--;
                questDisplay.updateDisplay(q);
                if (q.numEnemies == 0)
                {

                    toRemove.Add(q);
                }
            }
        }

        if (toRemove != null)
        {
            foreach (Quest q in toRemove)
                completeQuest(q);
        }

        
    }

    private void completeQuest(Quest q)
    {
        Debug.Log("Finsihed Quest: " + q.name);
        Debug.Log("Quest reward added +" + q.reward);
        gameObject.GetComponent<PlayerInfo>().gold += q.reward;
        playerQuests.Remove(q); //remove from player
        questDisplay.removeQuest(q); //remove from display
    }
}
