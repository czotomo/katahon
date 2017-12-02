using System;
using Assets.Scripts.Quests;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        public PlayerStats PlayerStats;
        private BagelSpawner _bagelSpawner;
        private QuestManager _questManager;
        private float _gameTime;
        public Text gameOverText;

        void Start()
        {
            gameOverText.gameObject.SetActive(false);
            _gameTime = 0f;
            _questManager = FindObjectOfType<QuestManager>();
            _bagelSpawner = FindObjectOfType<BagelSpawner>();
        }

        void Update()
        {
            _gameTime += Time.timeSinceLevelLoad;
            var moveVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            transform.position += new Vector3(moveVector.x, moveVector.y) * GetSpeed() * Time.deltaTime;
            PlayerStats.UpdateStats();

            if(PlayerStats.PlHunger <= 0.1f)
            {
                Die();
            }
        }

        private void Die()
        {
            gameOverText.gameObject.SetActive(true);
            Time.timeScale = 0;
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
            else if (collision.gameObject.CompareTag("Bagel"))
            {
                PlayerStats.Eat(Bagel.Value);
                Destroy(collision.gameObject);
                _bagelSpawner.CreateBagel();
            }
        }
    }
}