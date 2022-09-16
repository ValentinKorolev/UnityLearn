using UnityEngine;
using UnityEngine.InputSystem;

namespace Learn
{
    public class Hero : MonoBehaviour
    {       
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpPower;
        [SerializeField] LayerCheck _groundCheck;

        private Rigidbody2D _rigidbody;
        private Vector2 _direction;
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;
        private bool _isGround;

        private static readonly int IsRunningKey = Animator.StringToHash("is-runnig");
        private static readonly int IsGroundKey = Animator.StringToHash("is-ground");
        private static readonly int IsFallKey = Animator.StringToHash("vertical-vector");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            _isGround = IsGround();
        }
        private void FixedUpdate()
        {
            var xVelocity = _direction.x * _speed;
            var yVelocity = CalculateYVelocity();
            _rigidbody.velocity = new Vector2(xVelocity, yVelocity);

            //Animation
            _animator.SetBool(IsGroundKey, _isGround);
            _animator.SetFloat(IsFallKey, _rigidbody.velocity.y);
            _animator.SetBool(IsRunningKey, _direction.x != 0);

            UpdateSpriteDirection();
        }

        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        private float CalculateYVelocity()
        {
            bool isJumpPressing = _direction.y > 0;
            float yVelocity = _rigidbody.velocity.y;

            if (isJumpPressing)
            {
                yVelocity = CalculateJumpVelocity(yVelocity);
            }
            
            return yVelocity;
        }

        private float CalculateJumpVelocity(float yVelocity)
        {
            var isFalling = _rigidbody.velocity.y <= 0.001f;

            if (!isFalling) return yVelocity;

            if (_isGround)
            {
                yVelocity += _jumpPower;
            }
            else if (_rigidbody.velocity.y > 0)
            {
                yVelocity *= 0.5f;
            }
            return yVelocity;
        }

        private bool IsGround()
        {
            return _groundCheck._isTouchingGroundLayer;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = IsGround() ? Color.green : Color.red;
            Gizmos.DrawSphere(transform.position, 0.3f);
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

