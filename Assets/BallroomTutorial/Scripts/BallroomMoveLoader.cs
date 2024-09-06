using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace BallroomTutorial.Scripts
{
    public class BallroomMoveLoader : MonoBehaviour
    {
        [SerializeField] private Animator _leadAnimator;
        [SerializeField] private ResetOnEnd _leadReset;
        
        [SerializeField] private Animator _followAnimator;
        [SerializeField] private ResetOnEnd _followReset;

        [Button("Load Move")]
        public void LoadMove(BallroomMove move)
        {
            _leadAnimator.runtimeAnimatorController = move.LeadAnimation;
            _leadReset.ResetTo(move.LeadPosition, move.LeadRotation);
            _leadAnimator.gameObject.SetActive(move.LeadAnimation != null);
            
            _followAnimator.runtimeAnimatorController = move.FollowAnimation;
            _followReset.ResetTo(move.FollowPosition, move.FollowRotation);
            _followAnimator.gameObject.SetActive(move.FollowAnimation != null);
        }
        
        [Button("Load Lead Move")]
        public void LoadLeadMove(BallroomMove move)
        {
            _leadAnimator.runtimeAnimatorController = move.LeadAnimation;
            _leadReset.ResetTo(move.LeadPosition, move.LeadRotation);
            _leadAnimator.gameObject.SetActive(move.LeadAnimation != null);
            
            _followAnimator.gameObject.SetActive(false);
        }
        
        [Button("Load Follow Move")]
        public void LoadFollowMove(BallroomMove move)
        {
            _leadAnimator.gameObject.SetActive(false);
            
            _followAnimator.runtimeAnimatorController = move.FollowAnimation;
            _followReset.ResetTo(move.FollowPosition, move.FollowRotation);
            _followAnimator.gameObject.SetActive(move.FollowAnimation != null);
        }
        
        [Button("Unload Move")]
        public void UnloadMove()
        {
            _leadAnimator.gameObject.SetActive(false);
            _leadAnimator.runtimeAnimatorController = null;
            _followAnimator.gameObject.SetActive(false);
            _followAnimator.runtimeAnimatorController = null;
        }
    }
}