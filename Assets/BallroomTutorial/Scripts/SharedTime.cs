using System;
using UnityEngine;

namespace BallroomTutorial.Scripts
{
    [CreateAssetMenu(menuName = "Shared Time", fileName = "SO_SharedTime_")]
    public class SharedTime : ScriptableObject
    {
        private static readonly float[] Steps = {0.25f, 0.5f, 1f, 1.5f, 2f}; 
        
        [SerializeField] private float _value;
        
        private int _stepIndex;
        
        public event Action OnValueChanged;
        
        public float Value => _value;

        public void GoToNext()
        {
            _stepIndex = (_stepIndex + 1) % Steps.Length;
            _value = Steps[_stepIndex];
            OnValueChanged?.Invoke();
        }

        public void Reset()
        {
            _stepIndex = 2;
            _value = Steps[_stepIndex];
            OnValueChanged?.Invoke();
        }
    }
}