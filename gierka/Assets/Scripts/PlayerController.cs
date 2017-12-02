using Assets.Scripts.Quests;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        public PlayerStats PlayerStats;

        private QuestManager _questManager;

        void Start()
        {
            _questManager = FindObjectOfType<QuestManager>();
        }

        void Update()
        {
            var moveVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            transform.position += new Vector3(moveVector.x, moveVector.y) * GetSpeed() * Time.deltaTime;
        }

        public float GetSpeed()
        {
            return PlayerStats.GetSpeed();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Building"))
            {
                Debug.Log("Jebło to jebło, po chuj drążyć temat.");
                var questHolder = collision.gameObject.GetComponent<QuestHolder>();
                if (questHolder != null)
                {
                    _questManager.Complete(questHolder.QuestName, PlayerStats);
                    Destroy(questHolder);
                }
            }
        }
    }
}