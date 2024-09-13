using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace BallroomTutorial.Scripts
{
    public class BallroomUIManager: MonoBehaviour
    {
        [SerializeField] private GameObject _scanningScreen;
        [SerializeField] private List<GameObject> _infoScreens;
        [SerializeField] private GameObject _moveSelectionScreen;
        [SerializeField] private GameObject _demoScreen;
        [SerializeField] private TMP_Text _moveName;

        private bool _trackedObjects;
        private List<GameObject> _screens;
        private BallroomMove _currentMove;

        private void Awake()
        {
            _screens = new List<GameObject>
            {
                _scanningScreen,
                _moveSelectionScreen,
                _demoScreen
            }.Concat(_infoScreens).ToList();
            
            DisplayScreen(_scanningScreen);
        }

        public void OnCoverTracked()
        {
            _trackedObjects = true;
            Debug.Log("Tracking found " + _trackedObjects);
            _currentMove = null;
            DisplayScreen(_moveSelectionScreen);
        }

        public void DisplayMove(BallroomMove move)
        {
            DisplayScreen(_demoScreen);
            _currentMove = move;
            _moveName.text = move.Name;
        }
        
        public void OnTrackingLost()
        {
            _trackedObjects = false;
            Debug.Log("Tracking lost " + _trackedObjects);
            DisplayScreen(_scanningScreen);
        }
        
        public void DisplayScreen(GameObject screen)
        {
            foreach (var s in _screens)
            {
                s.SetActive(s == screen);
            }
        }

        public void ReturnToHome()
        {
            if (!_trackedObjects) DisplayScreen(_scanningScreen);
            else if (_currentMove != null) DisplayMove(_currentMove);
            else DisplayScreen(_moveSelectionScreen);
        }
    }
}