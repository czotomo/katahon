using System.Collections.Generic;
using System.Security.Policy;
using Assets.Scripts.Quests;
using UnityEngine;

namespace Assets.Scripts
{
    public class QuestManager : MonoBehaviour
    {
        private List<Quest> _activeQuests = new List<Quest>();

        public QuestFactory questFactory;

        void Start()
        {
            _activeQuests.Add(questFactory.GenerateRandomReachDestinationQuest());
        }

        public void Add(Quest quest)
        {
            _activeQuests.Add(quest);
        }

        public void Complete(string questName) // should pass player reference here i guess
        {
            var completedQuest = _activeQuests.Find(q => q.Name.Equals(questName));
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
