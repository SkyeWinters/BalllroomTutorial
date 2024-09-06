using System.Collections.Generic;
using UnityEngine;

namespace BallroomTutorial.Scripts
{
    public class MoveSelectionScreen : MonoBehaviour
    {
        [SerializeField] private MoveButton _moveButtonPrefab;
        [SerializeField] private List<BallroomMove> _moves;
        [SerializeField] private List<MoveButton> _moveButtons;
        [SerializeField] private Transform _moveButtonContainer;
        [SerializeField] private BallroomUIManager _uiManager;
        [SerializeField] private BallroomMoveLoader _moveLoader;

        private void Awake()
        {
            _moveButtons = new List<MoveButton>();
            foreach (Transform move in _moveButtonContainer)
            {
                var moveButton = move.GetComponent<MoveButton>();
                if (moveButton != null)
                {
                    _moveButtons.Add(moveButton);
                }
            }
        }
        
        private void OnEnable()
        {
            while (_moveButtons.Count < _moves.Count)
            {
                var moveButton = Instantiate(_moveButtonPrefab, _moveButtonContainer);
                _moveButtons.Add(moveButton);
            }
            
            for (var i = 0; i < _moveButtons.Count; i++)
            {
                if (i >= _moves.Count)
                {
                    _moveButtons[i].gameObject.SetActive(false);
                    continue;
                }
                
                var move = _moves[i];
                var moveButton = _moveButtons[i];
                moveButton.gameObject.SetActive(true);
                moveButton.SetMove(OnMoveSelected, move);
            }
        }
        
        private void OnMoveSelected(BallroomMove move)
        {
            _moveLoader.LoadMove(move);
            _uiManager.DisplayMove(move);
        }
    }
}