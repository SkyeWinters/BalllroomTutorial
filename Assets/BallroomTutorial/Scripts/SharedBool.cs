using System;
using UnityEngine;

namespace BallroomTutorial.Scripts
{
    [CreateAssetMenu(menuName = "Shared Bool", fileName = "SO_SharedBool_")]
    public class SharedBool : ScriptableObject
    {
        [SerializeField] private bool _value;
        
        public event Action OnValueChanged;
        
        public bool Value => _value;
        
        public void SetValue(bool value)
        {
            _value = value;
            OnValueChanged?.Invoke();
        }
        
        public void ToggleValue()
        {
            SetValue(!_value);
        }
    }
}