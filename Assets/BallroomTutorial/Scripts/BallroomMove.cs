using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace BallroomTutorial.Scripts
{
    [CreateAssetMenu(menuName = "Ballroom Move", fileName = "SO_NewMove_BallroomMove", order = 0)]
    public class BallroomMove : ScriptableObject
    {
        [FormerlySerializedAs("_moveName")]
        [Header("General")]
        [Tooltip("The name of the move")]
        [SerializeField] private string _name;
        
        [Header("Lead Properties")]
        [Tooltip("The motion capture recording of the Lead's movements.")]
        [SerializeField] private RuntimeAnimatorController _leadAnimation;
        [Tooltip("The starting local position of the Lead.")]
        [SerializeField] private Vector3 _leadPosition;
        [Tooltip("The starting local rotation of the Lead.")]
        [SerializeField] private Vector3 _leadRotation;
        [Tooltip("The steps of the move for the Lead")]
        [SerializeField] private List<BallroomStep> _leadSteps;
        
        [Header("Follow Properties")]
        [Tooltip("The motion capture recording of the Follow's movements.")]
        [SerializeField] private RuntimeAnimatorController _followAnimation;
        [Tooltip("The starting local position of the Follow.")]
        [SerializeField] private Vector3 _followPosition;
        [Tooltip("The starting local rotation of the Follow.")]
        [SerializeField] private Vector3 _followRotation;
        [Tooltip("The steps of the move for the Follow")]
        [SerializeField] private List<BallroomStep> _followSteps;
        
        [Button("Add Lead Step")]
        public void AddLeadStep(Animator leadAnimator)
        {
            var step = new BallroomStep
            {
                Time = leadAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime,
                Position = leadAnimator.transform.localPosition,
                Rotation = leadAnimator.transform.localRotation
            };
            _leadSteps.Add(step);
        }
        
        [Button("Add Follow Step")]
        public void AddFollowStep(Animator followAnimator)
        {
            var step = new BallroomStep
            {
                Time = followAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime,
                Position = followAnimator.transform.localPosition,
                Rotation = followAnimator.transform.localRotation
            };
            _followSteps.Add(step);
        }
        
        /// <summary>
        /// The name of the move.
        /// </summary>
        public string Name => _name;
        
        /// <summary>
        /// The motion capture recording of the Lead's movements.
        /// </summary>
        public RuntimeAnimatorController LeadAnimation => _leadAnimation;

        /// <summary>
        /// The starting local position of the Lead.
        /// </summary>
        public Vector3 LeadPosition => _leadPosition;
        
        /// <summary>
        /// The starting local rotation of the Lead.
        /// </summary>
        public Vector3 LeadRotation => _leadRotation;
        
        /// <summary>
        /// The steps of the move for the Lead.
        /// </summary>
        public List<BallroomStep> LeadSteps => _leadSteps;
        
        /// <summary>
        /// The motion capture recording of the Follow's movements.
        /// </summary>
        public RuntimeAnimatorController FollowAnimation => _followAnimation;
        
        /// <summary>
        /// The starting local position of the Follow.
        /// </summary>
        public Vector3 FollowPosition => _followPosition;
        
        /// <summary>
        /// The starting local rotation of the Follow.
        /// </summary>
        public Vector3 FollowRotation => _followRotation;
        
        /// <summary>
        /// The steps of the move for the Follow.
        /// </summary>
        public List<BallroomStep> FollowSteps => _followSteps;
    }
}