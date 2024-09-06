using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetOnEnd : MonoBehaviour
{
    private Animator _animator;
    private Vector3 _initialPosition;
    private Quaternion _startingRotation;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        _initialPosition = transform.localPosition;
        _startingRotation = transform.localRotation;
    }

    private void Update()
    {
        var currentPlaybackTime = _animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
        if (!(currentPlaybackTime - Mathf.Floor(currentPlaybackTime) < 0.01) || _animator.IsInTransition(0)) return;
        
        transform.localPosition = _initialPosition;
        transform.localRotation = _startingRotation;
    }
    
    public void ResetTo(Vector3 position, Vector3 rotation)
    {
        _initialPosition = position;
        _startingRotation = Quaternion.Euler(rotation);
        
        transform.localPosition = position;
        transform.localEulerAngles = rotation;
    }
}
