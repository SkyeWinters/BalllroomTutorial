using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace BallroomTutorial.Scripts
{
    public class BallroomUIManager: MonoBehaviour
    {
        [SerializeField] private GameObject _scanningScreen;
        [SerializeField] private GameObject _infoScreen;
        [SerializeField] private GameObject _moveSelectionScreen;
        [SerializeField] private GameObject _demoScreen;
        [SerializeField] private TMP_Text _moveName;

        private bool _trackedObjects;
        private List<GameObject> _screens;

        private void Awake()
        {
            _screens = new List<GameObject>
            {
                _scanningScreen,
                _infoScreen,
                _moveSelectionScreen,
                _demoScreen
            };
            
            DisplayScreen(_scanningScreen);
        }

        public void OnCoverTracked()
        {
            Debug.Log("Tracking found " + _trackedObjects);
            DisplayScreen(_moveSelectionScreen);
        }

        public void DisplayMove(BallroomMove move)
        {
            DisplayScreen(_demoScreen);
            _moveName.text = move.Name;
        }
        
        public void OnTrackingLost()
        {
            Debug.Log("Tracking lost " + _trackedObjects);
            DisplayScreen(_scanningScreen);
        }
        
        private void DisplayScreen(GameObject screen)
        {
            foreach (var s in _screens)
            {
                s.SetActive(s == screen);
            }
        }
    }
}