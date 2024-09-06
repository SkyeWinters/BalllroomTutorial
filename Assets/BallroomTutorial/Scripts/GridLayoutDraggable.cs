using UnityEngine;
using UnityEngine.UI;

namespace BallroomTutorial.Scripts
{
    [RequireComponent(typeof(GridLayoutGroup))]
    public class GridLayoutDraggable : Draggable
    {
        [SerializeField] private int _childrenToIgnore = 0;
        
        private GridLayoutGroup _gridLayout;
        private float _startingPosition;
        
        protected override void Awake()
        {
            base.Awake();
            _gridLayout = GetComponent<GridLayoutGroup>();
            _startingPosition = transform.position.y;
            Bottom = _startingPosition;
        }

        private void OnEnable()
        {
            var children = Mathf.Max(_gridLayout.transform.childCount - _childrenToIgnore, 0);
            var height = _gridLayout.cellSize.y * children + _gridLayout.spacing.y * (children - 1);
            Top = _startingPosition + height;
            CanMove = children > 0;
        }
    }
}