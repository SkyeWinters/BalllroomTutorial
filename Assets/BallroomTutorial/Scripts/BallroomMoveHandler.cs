using System;
using System.Collections.Generic;
using System.Linq;
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
       
        private ResetOnEnd _resetOnEnd;
        private float _time;
        private float _playbackSpeed;
        private AudioSource _audioSource;
        private int _lastTime;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void LoadMove(BallroomMove move)
        {
            _currentMove = move;
            _animator.runtimeAnimatorController = Movements;
            _animator.gameObject.SetActive(Movements != null);
            _lastTime = 0;
            _playbackSpeed = 1;
            _resetOnEnd = GetComponentInChildren<ResetOnEnd>(true);
            if (_isLead) _resetOnEnd.ResetTo(move.LeadPosition, move.LeadRotation);
            else _resetOnEnd.ResetTo(move.FollowPosition, move.FollowRotation);
            PlayMovement();
        }

        private const int BeatsPerMeasure = 3;
        private const float BeatsPerPhrase = 12f;
        
        public void Update()
        {
            if (_animator.speed > 0 && _audioSource != null && _currentMove != null)
            {
                var time = _animator.GetCurrentAnimatorStateInfo(0).normalizedTime;

                if (time - _lastTime / BeatsPerPhrase > 0)
                {
                    _audioSource.pitch = _lastTime % BeatsPerMeasure == 1 ? 0.9f : 1;
                    if (_lastTime % BeatsPerPhrase != 0) _audioSource.Play();
                    _lastTime += 1;
                }
            }
        }

        public void UnloadMove()
        {
            StopMovement();
            _currentMove = null;
            _animator.runtimeAnimatorController = null;
            _animator.gameObject.SetActive(false);
        }
        
        public void StopMovement()
        {
            _animator.speed = 0;
        }
        
        public void PlayMovement()
        {
            _animator.speed = _playbackSpeed;
        }
        
        public void SetSpeed(float speed)
        {
            _playbackSpeed = speed;
            _animator.speed = _animator.speed == 0 ? 0 : _playbackSpeed;
        }
        
        public void AdvanceTime(int stepIndex)
        {
            if (stepIndex < 0 || stepIndex >= Steps.Count) return;
            
            StopMovement();
            _animator.Play("Move", 0, Steps[stepIndex].Time);
            _animator.Update(0);
            _animator.transform.localPosition = Steps[stepIndex].Position;
            _animator.transform.localRotation = Steps[stepIndex].Rotation;
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