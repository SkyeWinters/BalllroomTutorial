using System;
using TMPro;
using UnityEngine;

namespace BallroomTutorial.Scripts
{
    public class BallroomTermButton : MonoBehaviour
    {
        [SerializeField] private TMP_Text _termName;
        [SerializeField] private TMP_Text _termBriefDescription;
        
        private BallroomTerm _term;
        private Action<BallroomTerm> _onTermSelected;
        
        public void SetTerm(BallroomTerm term, Action<BallroomTerm> onTermSelected)
        {
            _term = term;
            _termName.text = term.Term;
            _termBriefDescription.text = term.BriefDescription;
            _onTermSelected = onTermSelected;
        }
        
        public void OnTermSelected()
        {
            _onTermSelected?.Invoke(_term);
        }
    }
}