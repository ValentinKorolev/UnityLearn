using UnityEngine;
using UnityEngine.InputSystem;

namespace Learn
{
    public class HeroInputReader : MonoBehaviour
    {
        [SerializeField] private Hero _hero;
        private Vector2 _direction;

        public void Movement(InputAction.CallbackContext context)
        {
            _direction = context.ReadValue<Vector2>();
            _hero.SetDirection(_direction);
        }
    }
}


