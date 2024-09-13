using TMPro;
using UnityEngine;

namespace BallroomTutorial.Scripts
{
    public class TimeUI : MonoBehaviour
    {
        [SerializeField] private SharedTime _sharedTime;
        [SerializeField] private TMP_Text _timeText;
        
        private void Awake()
        {
            _sharedTime.OnValueChanged += UpdateTime;
        }

        private void UpdateTime()
        {
            _timeText.text = $"{FormatFloatWithoutLeadingZero(_sharedTime.Value)}";
        }

        private static string FormatFloatWithoutLeadingZero(float number)
        {
            return number is < 1 and > -1 ? number.ToString("0.##").TrimStart('0') : number.ToString("0.##");;
        }
    }
}