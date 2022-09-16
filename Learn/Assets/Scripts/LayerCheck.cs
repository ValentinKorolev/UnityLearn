using UnityEngine;

namespace Learn
{
    public class LayerCheck : MonoBehaviour
    {
        [SerializeField] private LayerMask _groundLayer;

        private Collider2D _collider;
        public bool _isTouchingGroundLayer;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _isTouchingGroundLayer = _collider.IsTouchingLayers(_groundLayer);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            _isTouchingGroundLayer = _collider.IsTouchingLayers(_groundLayer);
        }
    }
}

