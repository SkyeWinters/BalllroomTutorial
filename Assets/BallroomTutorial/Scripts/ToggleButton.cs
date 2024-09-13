using UnityEngine;
using UnityEngine.Events;

namespace BallroomTutorial.Scripts
{
    public class ToggleButton : MonoBehaviour
    {
        [SerializeField] private SharedBool _sharedBool;
        [SerializeField] private UnityEvent _onValueChanged;
        [SerializeField] private UnityEvent _onTurnedOn;
        [SerializeField] private UnityEvent _onTurnedOff;
        
        private void OnEnable()
        {
            _sharedBool.OnValueChanged += OnValueChanged;
        }
        
        private void OnDisable()
        {
            _sharedBool.OnValueChanged -= OnValueChanged;
        }
        
        public void Toggle()
        {
            _sharedBool.ToggleValue();
        }
        
        private void OnValueChanged()
        {
            _onValueChanged.Invoke();
            if (_sharedBool.Value)
            {
                _onTurnedOn.Invoke();
            }
            else
            {
                _onTurnedOff.Invoke();
            }
        }
    }
}