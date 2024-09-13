using UnityEngine;
using UnityEngine.Events;

namespace BallroomTutorial.Scripts
{
    public class BoolVisibilityHandler : MonoBehaviour
    {
        [SerializeField] private SharedBool _sharedBool;
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private UnityEvent _onTurnedOn;
        [SerializeField] private UnityEvent _onTurnedOff;
        [SerializeField] private bool _invert;
        
        private void OnEnable()
        {
            _sharedBool.OnValueChanged += OnValueChanged;
            OnValueChanged();
        }
        
        private void OnDisable()
        {
            _sharedBool.OnValueChanged -= OnValueChanged;
        }
        
        private void OnValueChanged()
        {
            if (_gameObject != null)
            {
                _gameObject.SetActive(_sharedBool.Value ^ _invert);
            }

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