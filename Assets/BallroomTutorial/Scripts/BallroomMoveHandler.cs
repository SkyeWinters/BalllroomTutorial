using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace BallroomTutorial.Scripts
{
    public class BallroomMoveHandler : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private bool _isLead;
        
        private BallroomMove _currentMove;
        private RuntimeAnimatorController Movements => _isLead ? _currentMove.LeadAnimation : _currentMove.FollowAnimation;
        private List<BallroomStep> Steps => _isLead ? _currentMove.LeadSteps : _currentMove.FollowSteps;
       
        private float _time;
        private float _playbackSpeed;
        
        public void LoadMove(BallroomMove move)
        {
            _currentMove = move;
            _animator.runtimeAnimatorController = Movements;
            _animator.gameObject.SetActive(Movements != null);
            _playbackSpeed = 1;
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
            _animator.speed = _playbackSpeed;
        }
        
        [Button("Toggle Speed")]
        public void SetSpeed(float speed)
        {
            _playbackSpeed = speed;
            _animator.speed = _animator.speed == 0 ? 0 : _playbackSpeed;
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

        public void AdvanceToNextTime()
        {
            var currentTime = _animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
            currentTime -= Mathf.Floor(currentTime);
            var nextIndex = 0;
            
            for (var i = 0; i < Steps.Count; i++)
            {
                if (currentTime < (Steps[i].Time - Mathf.Floor(Steps[i].Time)))
                {
                    nextIndex = i;
                    break;
                }
            }
            
            AdvanceTime(nextIndex);
        }
        
        public void RetreatToPreviousTime()
        {
            var currentTime = _animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
            currentTime -= Mathf.Floor(currentTime);
            var previousIndex = 0;
            
            for (var i = 0; i < Steps.Count; i++)
            {
                if (currentTime > (Steps[i].Time - Mathf.Floor(Steps[i].Time)))
                {
                    previousIndex = i;
                }
            }
            
            AdvanceTime(previousIndex);
        }
    }
}