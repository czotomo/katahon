using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;
using Assets.Scripts.Quests;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class QuestManager : MonoBehaviour
    {
        private const float Delay = 5.0f;

        private const float RepeatTime = 5.0f;

        private const int QuestsLimit = 5;

        public Image doge;

        private List<Quest> _activeQuests = new List<Quest>();

        public QuestFactory questFactory;

        void Start()
        {
            AddNewQuest();
            InvokeRepeating("AddNewQuestIfPossible", Delay, RepeatTime);
        }

        public void Add(Quest quest)
        {
            _activeQuests.Add(quest);
        }

        public void Complete(string questName, PlayerStats playerStats)
        {
            var completedQuest = _activeQuests.Find(q => q.Name.Equals(questName));
            if (completedQuest == null)
            {
                Debug.Log("This quest was not found in active quests!");
            }
            else
            {
                completedQuest.OnQuestCompleted(playerStats);
                _activeQuests.Remove(completedQuest);
                StartCoroutine(ShowDoge());
            }
        }

        private IEnumerator ShowDoge()
        {
            doge.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            doge.gameObject.SetActive(false);
        }

        private void AddNewQuest()
        {
            var quest = questFactory.GenerateRandomReachDestinationQuest();
            if (quest != null)
            {
                _activeQuests.Add(quest);
            }
        }

        private void AddNewQuestIfPossible()
        {
            if (_activeQuests.Count < QuestsLimit)
            {
                AddNewQuest();
            }
        }

        public string ConcatenateQuestNames()
        {
            var builder = new StringBuilder();
            foreach (var quest in _activeQuests)
            {
                builder.Append(quest.Name);
                builder.Append(Environment.NewLine);
            }
            return builder.ToString().Trim();
        }
    }
}
