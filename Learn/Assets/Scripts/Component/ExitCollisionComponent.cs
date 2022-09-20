using UnityEngine;
using UnityEngine.Events;

namespace Learn.Component
{
    public class ExitCollisionComponent : MonoBehaviour
    {
        [SerializeField] private string _tag;
        [SerializeField] private UnityEvent _action;
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(_tag))
            {
                _action?.Invoke();
            }
        }
    }
}
