using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest System/Quest", fileName = "New Quest")]
public class Quest : ScriptableObject
{
    [Header("Info")]
    public string Name;
    public string ID;
    public int QuestGoal;

    [Header("Description")]
    [TextArea]public string Description;

    [Header("Reward")]
    public int GoldReward;
    public int ExpReward;
    public QuestItemReward ItemReward;

    [HideInInspector]  public int CurrentStatus;
    [HideInInspector]  public bool QuestComplited;
    [HideInInspector] public bool QuestAccepted;

    public void AddProgress(int amount)
    {
        CurrentStatus += amount;
        if(CurrentStatus >= QuestGoal)
        {
            CurrentStatus = QuestGoal;
            QuestIsCompleted();
        }
    }

    private void QuestIsCompleted()
    {
        if (QuestComplited)
        {
            return;
        }

        QuestComplited = true;
    }

    public void ResetQuest()
    {
        QuestAccepted = false;
        QuestComplited = false;
        CurrentStatus = 0;
    }
}

[Serializable]
public class QuestItemReward
{
    public InventoryItem Item; 
    public int Quantity; 
}
