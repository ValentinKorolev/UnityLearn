using UnityEngine;

namespace Learn
{
    public class Elevator : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }


        private void FixedUpdate()
        {
            var yVelocity = CalculateYVelocuty();
                  
           _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, yVelocity);
                                
        }

        private float CalculateYVelocuty()
        {
            float yVelocity =_rigidbody.velocity.y;

            if (transform.position.y < 4 && transform.position.y <=0.5)
            {               
                yVelocity += _speed;
                Debug.Log($"Elevator, velocityY = {yVelocity}");
            }
            else if(transform.position.y >= 4)
            {
                yVelocity -= _speed;
                Debug.Log($"Elevator ,velocityY = {yVelocity}");
            }

            return yVelocity;
        }
    }
}

