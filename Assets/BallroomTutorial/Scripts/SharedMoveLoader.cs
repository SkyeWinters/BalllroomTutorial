using System;
using UnityEngine;

namespace BallroomTutorial.Scripts
{
    [CreateAssetMenu(menuName = "Shared Move Loader", fileName = "SO_SharedMoveLoader_")]
    public class SharedMoveLoader : ScriptableObject
    {
        [SerializeField] private BallroomMoveLoader _value;

        public BallroomMoveLoader Value => _value;
        public event Action OnValueChanged; 
        
        public void SetValue(BallroomMoveLoader value)
        {
            _value = value;
            OnValueChanged?.Invoke();
        }
        
        public void LoadMove(BallroomMove move)
        {
            _value.LoadMove(move);
        }
        
        public void UnloadMove()
        {
            _value.UnloadMove();
        }
        
        public void StopMovement()
        {
            _value.StopMovement();
        }
        
        public void PlayMovement()
        {
            _value.PlayMovement();
        }
        
        public void NextStep()
        {
            _value.JumpToNextStep();
        }
        
        public void PreviousStep()
        {
            _value.RetreatToPreviousStep();
        }
    }
}