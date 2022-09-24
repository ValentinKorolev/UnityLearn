using UnityEngine;

namespace Prisoner
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private Vector2 _direction;
        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        private void Update()
        {
            var deltaX = _direction.x * _speed * Time.deltaTime;
            var newXPosition = transform.position.x + deltaX;
            var deltaY = _direction.y * _speed * Time.deltaTime;
            var newYPosition = transform.position.y + deltaY;

            if (_direction.x != 0)
            {
                transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);
            }
            else if(_direction.y != 0)
            {
                transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
            }
        }
    }
}

