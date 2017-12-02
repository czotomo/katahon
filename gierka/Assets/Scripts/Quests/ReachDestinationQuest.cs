using UnityEngine;

namespace Assets.Scripts.Quests
{
    public class ReachDestinationQuest : Quest
    {
        public override void OnQuestCompleted(PlayerStats stats)
        {
            Debug.Log("O kurwa udało się!");
            stats.Learn(5.0f);
        }
    }
}
