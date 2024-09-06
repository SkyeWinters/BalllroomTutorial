using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetOnEnd : MonoBehaviour
{
    private Animator animator;
    private Vector3 initialPosition;
    private Quaternion startingRotation;

    void Start()
    {
        // Get the Animator component
        animator = GetComponent<Animator>();

        // Save the initial position
        initialPosition = transform.localPosition;
        startingRotation = transform.localRotation;
    }

    void Update()
    {
        // Check if the animation has finishe
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime - Mathf.Floor(animator.GetCurrentAnimatorStateInfo(0).normalizedTime) < 0.01 && !animator.IsInTransition(0))
        {
            // Reset position to the initial position
            transform.localPosition = initialPosition;
            transform.localRotation = startingRotation;
        }
    }
    
}
