using UnityEngine;

namespace Learn
{
    public class Elevator : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Rigidbody2D _rigidbody;
        private float _startPosY;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.isKinematic = false;
            _startPosY = transform.position.y;
        }

        public void ElevatorMove()
        {
            Debug.Log("ElevatorUp");

            if(_rigidbody.isKinematic == false && _startPosY <  _startPosY + 0.5f)
            {
                _rigidbody.isKinematic = true;
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y + _speed);

            }else if (transform.position.y > _startPosY)
            {
                _rigidbody.isKinematic = true;
                Debug.Log("ElevatorDown");
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, (_rigidbody.velocity.y *0.5f)* Time.deltaTime);
                _rigidbody.isKinematic = false;
            }
           
        }

        public void ElevatorStop()
        {
            Debug.Log("ElevatorStop");
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y - _speed);
        }
    }
}

