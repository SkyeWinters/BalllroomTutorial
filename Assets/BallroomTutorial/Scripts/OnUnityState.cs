using UnityEngine;
using UnityEngine.Events;

namespace BallroomTutorial.Scripts
{
    internal class OnUnityState : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onAwake;
        [SerializeField] private UnityEvent _onStart;
        [SerializeField] private UnityEvent _onEnable;
        [SerializeField] private UnityEvent _onDisable;
        
        private void Awake()
        {
            _onAwake.Invoke();
        }
        
        private void Start()
        {
            _onStart.Invoke();
        }
        
        private void OnEnable()
        {
            _onEnable.Invoke();
        }
        
        private void OnDisable()
        {
            _onDisable.Invoke();
        }
    }
}