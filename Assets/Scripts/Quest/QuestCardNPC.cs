using System.Collections;
using TMPro;
using UnityEngine;

public class QuestCardNPC : QuestCard
{
    [SerializeField] private TextMeshProUGUI questRewardTMP;

    public override void ConfigQuestUI(Quest quest)
    {
        base.ConfigQuestUI(quest);
        questRewardTMP.text = $"- {quest.GoldReward} Gold\n" + $"- {quest.ExpReward} Exp\n" + $"- x{quest.ItemReward.Item.Quantity} {quest.ItemReward.Item.Name}";
    }

    public void AcceptQuest()
    {
        if (QuestToComplete == null) return;
        QuestToComplete.QuestAccepted = true;
        QuestManager.Instance.AceptQuest(QuestToComplete);
        gameObject.SetActive(false);
    }
}
