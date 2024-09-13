using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace BallroomTutorial.Scripts
{
    public class BallroomMoveHandler : MonoBehaviour
    {
        private readonly float[] SPEEDS = new[] { 1f, 1.5f, 2f, 0.25f, 0.5f, 0.75f };
        
        [SerializeField] private Animator _animator;
        [SerializeField] private bool _isLead;
        
        private BallroomMove _currentMove;
        private RuntimeAnimatorController Movements => _isLead ? _currentMove.LeadAnimation : _currentMove.FollowAnimation;
        private List<BallroomStep> Steps => _isLead ? _currentMove.LeadSteps : _currentMove.FollowSteps;
       
        private float _time;
        private int _playbackSpeedIndex;
        private float PlaybackSpeed => SPEEDS[_playbackSpeedIndex];
        
        public void LoadMove(BallroomMove move)
        {
            _currentMove = move;
            _animator.runtimeAnimatorController = Movements;
            _animator.gameObject.SetActive(Movements != null);
            _playbackSpeedIndex = 0;
            PlayMovement();
        }

        public void UnloadMove()
        {
            _currentMove = null;
            _animator.runtimeAnimatorController = null;
            _animator.gameObject.SetActive(false);
        }
        
        [Button("Stop")]
        public void StopMovement()
        {
            _animator.speed = 0;
        }
        
        [Button("Play")]
        public void PlayMovement()
        {
            _animator.speed = PlaybackSpeed;
        }
        
        [Button("Toggle Speed")]
        public void ToggleSpeed()
        {
            _playbackSpeedIndex = (_playbackSpeedIndex + 1) % SPEEDS.Length;
        }
        
        [Button("Jump To")]
        public void AdvanceTime(int stepIndex)
        {
            if (stepIndex < 0 || stepIndex >= Steps.Count) return;
            
            StopMovement();
            _animator.Play("Move", 0, Steps[stepIndex].Time);
            _animator.Update(0);
            _animator.transform.localPosition = Steps[stepIndex].Position;
            _animator.transform.localRotation = Steps[stepIndex].Rotation;
            
            Debug.Log("Jumped to step " + stepIndex);
        }
    }
}