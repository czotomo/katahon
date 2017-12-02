using UnityEngine;

namespace Assets.Scripts.Quests
{
    public class ReachDestinationQuest : Quest
    {
        public override void OnQuestCompleted()
        {
            Debug.Log("O kurwa udało się!");
        }
    }
}
