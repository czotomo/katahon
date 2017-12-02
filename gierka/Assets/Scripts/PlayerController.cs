using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        public PlayerStats PlayerStats;

        void Update()
        {
            var moveVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            transform.position += new Vector3(moveVector.x, moveVector.y) * GetSpeed() * Time.deltaTime;
        }

        public float GetSpeed()
        {
            return PlayerStats.GetSpeed();
        }

    }
}