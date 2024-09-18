using System.Runtime.InteropServices;
using UnityEngine;

namespace BallroomTutorial.Scripts
{
    public class AudioSession : MonoBehaviour
    {
        [DllImport("__Internal")]
        private static extern void _SetAudioSession();

        void Start()
        {
#if !UNITY_EDITOR && UNITY_IOS
        _SetAudioSession();
#endif
        }
    }
}