using System;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BallroomTutorial.Scripts
{
    [RequireComponent(typeof(Button))]
    public class MoveButton : MonoBehaviour
    {
        [SerializeField, ReadOnly] private BallroomMove _move;
        [SerializeField] private TMP_Text _moveName;
        
        public void SetMove(Action<BallroomMove> onMoveSelected, BallroomMove move)
        {
            var button = GetComponent<Button>();
            _move = move;
            _moveName.text = move.Name;
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => onMoveSelected?.Invoke(_move));
        }
    }
}