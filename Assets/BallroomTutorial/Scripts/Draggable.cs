using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BallroomTutorial.Scripts
{
    [RequireComponent(typeof(RectTransform))]
    public class Draggable : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler
    {
        [SerializeField] private float _pressDuration = 0.5f;
        [SerializeField] private float _stretchAmount = 10f;
        [SerializeField] private float _stretchDuration = 0.5f;

        private RectTransform _rectTransform;
        private float _startTime;
        private bool _isPressing;

        protected float Top { get; set; }
        protected float Bottom { get; set; }
        protected bool CanMove { get; set; } = true;

        protected virtual void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            Top = _rectTransform.position.y;
            Bottom = _rectTransform.position.y;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _startTime = Time.time;
            _isPressing = true;
            Debug.Log("Pointer Down");
        }

        public void OnPointerMove(PointerEventData eventData)
        {
            if (!CanMove || !_isPressing || Time.time - _startTime < _pressDuration) return;
        
            var delta = eventData.delta;
            var newYPos = _rectTransform.position.y + delta.y;
            var stretch = Mathf.Clamp(newYPos, Bottom - _stretchAmount, Top + _stretchAmount);
            _rectTransform.position = new Vector3(_rectTransform.position.x, stretch, _rectTransform.position.z);
        }

        public void Update()
        {
            if (_isPressing || !CanMove) return;
            HandleDrift();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _isPressing = false;
        }

        private void HandleDrift()
        {
            var position = _rectTransform.position;

            if (position.y > Top)
            {
                position.y -= 5f * Time.deltaTime;
                position.y = Mathf.Max(Top, position.y);
            }
            else if (position.y < Bottom)
            {
                position.y += 5f * Time.deltaTime;
                position.y = Mathf.Min(Bottom, position.y);
            }

            _rectTransform.position = position;
        }
    }
}
