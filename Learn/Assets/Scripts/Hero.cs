using UnityEngine;

namespace Learn
{
    public class Hero : MonoBehaviour
    {       
        [SerializeField] private float _speed;

        private Rigidbody2D _rigidbody;
        private Vector2 _direction;
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;

        private static readonly int IsRunnigKey = Animator.StringToHash("is-runnig");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = new Vector2(_direction.x * _speed,_direction.y);

            //Animation
            _animator.SetBool(IsRunnigKey, _direction.x != 0);

            UpdateSpriteDirection();
        }

        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        private void UpdateSpriteDirection()
        {
            if(_direction.x < 0)
            {
                _spriteRenderer.flipX = true;
            }
            else if(_direction.x > 0)
            {
                _spriteRenderer.flipX = false;
            }
        }

    }
}

