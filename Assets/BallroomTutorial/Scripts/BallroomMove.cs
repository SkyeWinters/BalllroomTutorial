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
        
        [Header("Follow Properties")]
        [Tooltip("The motion capture recording of the Follow's movements.")]
        [SerializeField] private RuntimeAnimatorController _followAnimation;
        [Tooltip("The starting local position of the Follow.")]
        [SerializeField] private Vector3 _followPosition;
        [Tooltip("The starting local rotation of the Follow.")]
        [SerializeField] private Vector3 _followRotation;
        
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
    }
}