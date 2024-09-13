using UnityEngine;

namespace BallroomTutorial.Scripts
{
    [CreateAssetMenu(menuName = "Ballroom Term", fileName = "SO_BallroomTerm_", order = 0)]
    public class BallroomTerm : ScriptableObject
    {
        public string Term;
        public string BriefDescription;
        public string FullDescription;
    }
}