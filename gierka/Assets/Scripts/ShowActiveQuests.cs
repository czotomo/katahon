using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ShowActiveQuests : MonoBehaviour
    {
        private QuestManager _questManager;

        private Text _text;

        void Start ()
        {
            _questManager = FindObjectOfType<QuestManager>();
            _text = GetComponent<Text>();
        }

        void Update()
        {
            _text.text = _questManager.ConcatenateQuestNames();
        }
    }
}
