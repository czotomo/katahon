using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerController : MonoBehaviour
    {

        private float _speed = 10.0f;

        void Update()
        {
            var moveVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            transform.position += new Vector3(moveVector.x, moveVector.y) * GetSpeed() * Time.deltaTime;
        }

        public float GetSpeed()
        {
            return _speed;
        }

    }
}