using Sirenix.OdinInspector;
using UnityEngine;

namespace BallroomTutorial.Scripts
{
    public class BallroomMoveLoader : MonoBehaviour
    {
        [SerializeField] private BallroomMoveHandler _leadMoveHandler;
        [SerializeField] private ResetOnEnd _leadReset;
        
        [SerializeField] private BallroomMoveHandler _followMoveHandler;
        [SerializeField] private ResetOnEnd _followReset;

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
        
        [Button("Load Move")]
        public void LoadMove(BallroomMove move)
        {
            _leadMoveHandler.LoadMove(move);
            _leadReset.ResetTo(move.LeadPosition, move.LeadRotation);
            
            _followMoveHandler.LoadMove(move);
            _followReset.ResetTo(move.FollowPosition, move.FollowRotation);
        }
        
        [Button("Load Lead Move")]
        public void LoadLeadMove(BallroomMove move)
        {
            _leadMoveHandler.LoadMove(move);
            _leadReset.ResetTo(move.LeadPosition, move.LeadRotation);
            
            _followMoveHandler.gameObject.SetActive(false);
        }
        
        [Button("Load Follow Move")]
        public void LoadFollowMove(BallroomMove move)
        {
            _leadMoveHandler.gameObject.SetActive(false);
            
            _followMoveHandler.LoadMove(move);
            _followReset.ResetTo(move.FollowPosition, move.FollowRotation);
        }
        
        [Button("Unload Move")]
        public void UnloadMove()
        {
            _leadMoveHandler.UnloadMove();
            _followMoveHandler.UnloadMove();
        }
    }
}