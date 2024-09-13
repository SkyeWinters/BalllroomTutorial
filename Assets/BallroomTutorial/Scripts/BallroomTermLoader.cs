using System.Collections.Generic;
using UnityEngine;

namespace BallroomTutorial.Scripts
{
    public class BallroomTermLoader : MonoBehaviour
    {
        [SerializeField] private List<BallroomTerm> _terms;
        [SerializeField] private BallroomTermButton _termButtonPrefab;

        private void Start()
        {
            LoadTerms();
        }

        private void LoadTerms()
        {
            foreach (var term in _terms)
            {
                var termButton = Instantiate(_termButtonPrefab, transform);
                termButton.SetTerm(term, OnTermSelected);
            }
        }

        private void OnTermSelected(BallroomTerm term)
        {
            Debug.Log("Selected term: " + term.Term);
        }
    }
}