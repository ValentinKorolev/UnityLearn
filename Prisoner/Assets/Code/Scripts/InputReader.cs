using UnityEngine;
using UnityEngine.InputSystem;

namespace Prisoner
{
    public class InputReader : MonoBehaviour
    {
        [SerializeField] private Hero _hero;

        private Vector2 _direction;

        public void Move(InputAction.CallbackContext callbackContext)
        {
            _direction = callbackContext.ReadValue<Vector2>();
            _hero.SetDirection(_direction);
        }
    }
}

