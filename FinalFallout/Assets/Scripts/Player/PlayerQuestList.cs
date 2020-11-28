using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQuestList : MonoBehaviour
{
    public List<Quest> playerQuests;
    private List<Quest> toRemove;


    public void addQuest(Quest _quest)
    {
        playerQuests.Add(_quest);
    }

    public void defeatEnemy(MonsterClass enemy)
    {
        foreach(Quest q in playerQuests)
        {
            if(enemy.name == q.enemy.name)
            {
                q.numEnemies--;
                if(q.numEnemies == 0)
                {
                    toRemove.Add(q);
                }
            }
        }
        
        foreach (Quest q in toRemove)
            completeQuest(q);
    }

    private void completeQuest(Quest q)
    {
        gameObject.GetComponent<PlayerInfo>().gold += q.reward;
        playerQuests.Remove(q);
    }
}
