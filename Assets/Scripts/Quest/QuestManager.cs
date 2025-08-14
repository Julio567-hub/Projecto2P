using System.Collections;
using UnityEngine;


public class QuestManager : Singleton<QuestManager>
{
    [Header("Quest")]
    [SerializeField] private Quest[] quests;

    [Header("NPC Quest Panel")]
    [SerializeField] private QuestCardNPC questCardNpcPrefab;
    [SerializeField] private Transform npcPanelContainer;

    [SerializeField] private QuestCardPlayer questCardPlayerPrefab;
    [SerializeField] private Transform playerQuestContainer;

    private void Start()
    {
        LoadQuestIntoNPCPanel();
    }

    public void AceptQuest(Quest quest)
    {
        QuestCardPlayer cardPlayer = Instantiate(questCardPlayerPrefab, playerQuestContainer);
        cardPlayer.ConfigQuestUI(quest);
    }

    public void AddProgress(string questID, int amount)
    {
        Quest questToUpdate = QuestExist(questID);
        if (questToUpdate == null) return;
        if (questToUpdate.QuestAccepted)
        {
            questToUpdate.AddProgress(amount);
        }
    }

    private Quest QuestExist(string questID)
    {
        foreach(Quest quest in quests)
        {
            if (quest.ID == questID)
            {
                return quest;
            }
        }
        return null;
    }

    private void LoadQuestIntoNPCPanel()
    {
        for (int i = 0; i < quests.Length; i++)
        {
           QuestCardNPC npcCard = Instantiate(questCardNpcPrefab, npcPanelContainer);
            npcCard.ConfigQuestUI(quests[i]);
        }
    }

    private void OnEnable()
    {
        for (int i = 0; i < quests.Length; i++)
        {
            quests[i].ResetQuest();
        }
    }
}
