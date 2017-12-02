using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Quests
{
    public class QuestFactory : MonoBehaviour
    {
        public GameObject[] Buildings;

        private readonly System.Random _random = new System.Random();

        public Quest GenerateRandomReachDestinationQuest()
        {
            GameObject building = RandomBuildingWithoutQuest();
            if (building == null)
            {
                return null;
            }
            string questName = RandomQuestName(5, building.name);

            var questHolder = building.AddComponent<QuestHolder>();
            questHolder.QuestName = questName;

            Debug.Log(String.Format("Created quest {0} in building {1}", questName, building.name));
            return new ReachDestinationQuest { Name = questName};
        }

        private string RandomQuestName(int length, string buildingName)
        {
            string[] prefixes =  { "Ruszaj do", "Biegnij do", "Pędź do" };
            string[] eventTypes = { "kolosa", "wykład", "ćwiczenia", "laborki" };
            string[] subjects = { "WDI", "ASD", "" };

            string randomPrefix = prefixes[_random.Next(prefixes.Length)];
            string randomEventType = eventTypes[_random.Next(eventTypes.Length)];
            string randomsubject = subjects[_random.Next(subjects.Length)];

            return String.Format("{0} {1} na {2} z {3}", randomPrefix, buildingName, randomEventType, randomsubject);
        }

        private GameObject RandomBuilding()
        {
            return Buildings[_random.Next(Buildings.Length)];
        }

        private GameObject RandomBuildingWithoutQuest()
        {
            var validBuildings = Buildings.ToList().Where(b => b.GetComponent<QuestHolder>() == null).ToArray();
            if (validBuildings.Length == 0)
            {
                return null;
            }
            return validBuildings[_random.Next(validBuildings.Length)];
        }
    }
}
