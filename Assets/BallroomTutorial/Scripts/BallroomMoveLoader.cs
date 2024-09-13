using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace BallroomTutorial.Scripts
{
    public class BallroomMoveLoader : MonoBehaviour
    {
        [SerializeField] private BallroomMoveHandler _leadMoveHandler;
        [SerializeField] private BallroomMoveHandler _followMoveHandler;

        [SerializeField] private BallroomMove _defaultMove;
        [SerializeField] private SharedMoveLoader _moveLoader;
        [SerializeField] private SharedTime _playbackSpeed;

        private void OnEnable()
        {
            _playbackSpeed.OnValueChanged += SetPlaybackSpeed;
            if (_defaultMove != null)
            {
                _leadMoveHandler.LoadMove(_defaultMove);
                _followMoveHandler.LoadMove(_defaultMove);
            }
        }
        
        private void OnDisable()
        {
            _playbackSpeed.OnValueChanged -= SetPlaybackSpeed;
        }

        [Button("Stop")]
        public void StopMovement()
        {
            _leadMoveHandler.StopMovement();
            _followMoveHandler.StopMovement();
        }
        
        [Button("Play")]
        public void PlayMovement()
        {
            _leadMoveHandler.PlayMovement();
            _followMoveHandler.PlayMovement();
        }
        
        [Button("Jump To")]
        public void JumpToStep(int stepIndex)
        {
            _leadMoveHandler.AdvanceTime(stepIndex);
            _followMoveHandler.AdvanceTime(stepIndex);
        }
        
        [Button("Next Step")]
        public void JumpToNextStep()
        {
            _leadMoveHandler.AdvanceToNextTime();
            _followMoveHandler.AdvanceToNextTime();
        }
        
        [Button("Previous Step")]
        public void RetreatToPreviousStep()
        {
            _leadMoveHandler.RetreatToPreviousTime();
            _followMoveHandler.RetreatToPreviousTime();
        }
        
        [Button("Load Move")]
        public void LoadMove(BallroomMove move)
        {
            _leadMoveHandler.LoadMove(move);
            _followMoveHandler.LoadMove(move);
            
            _moveLoader.SetValue(this);
        }

        public void SetMoveLoader()
        {
            _moveLoader.SetValue(this);
        }
        
        [Button("Unload Move")]
        public void UnloadMove()
        {
            _leadMoveHandler.UnloadMove();
            _followMoveHandler.UnloadMove();
        }

        private void SetPlaybackSpeed()
        {
            _leadMoveHandler.SetSpeed(_playbackSpeed.Value);
            _followMoveHandler.SetSpeed(_playbackSpeed.Value);
        }
    }
}