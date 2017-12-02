using System.Collections.Generic;
using Assets.Scripts.Quests;
using UnityEngine;

namespace Assets.Scripts
{
    public class QuestManager : MonoBehaviour {

        private List<Quest> activeQuests = new List<Quest>();

        void Start()
        {

        }

        public void Add(Quest quest)
        {
            activeQuests.Add(quest);
        }

        public void Complete(string questName) // should pass player reference here i guess
        {
            var completedQuest = activeQuests.Find(q => q.Name.Equals(questName));
            if (completedQuest == null)
            {
                Debug.Log("This quest was not found in active quests!");
            }
            else
            {
                   completedQuest.OnQuestCompleted();
            }
        }
    }
}
