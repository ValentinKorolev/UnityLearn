using UnityEngine;
using UnityEngine.Events;

namespace Learn 
{
    public class SpriteAnimation : MonoBehaviour
    {
        [SerializeField] private byte _frameRate;
        [SerializeField] private bool _loop;
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private UnityEvent _onComplete;

        private SpriteRenderer _render;
        private byte _currentSpriteIndex;
        private float _secondsPerFrame;
        private float _nextFrameTime;

        private void Awake()
        {
            _render = GetComponent<SpriteRenderer>();
        }

        private void OnEnable()
        {
            _currentSpriteIndex = default;
            _secondsPerFrame = 1f / _frameRate;//кадров в секунду
            _nextFrameTime = Time.time + _secondsPerFrame; //Time.time - время начало этого кадра 
        }

        private void Update()
        {
            if(_nextFrameTime > Time.time) //?
            {
                return;
            }

            if(_currentSpriteIndex >= _sprites.Length)
            {
                if (_loop)
                {
                    _currentSpriteIndex = default;
                }
                else
                {
                    enabled = false;
                    _onComplete?.Invoke();
                    return;
                }
            }

            _render.sprite = _sprites[_currentSpriteIndex];
            _nextFrameTime += _secondsPerFrame; //??
            _currentSpriteIndex++;
        }
    }
}


