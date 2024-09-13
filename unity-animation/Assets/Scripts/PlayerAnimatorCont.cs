using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorCont : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // No need to update here, update from PlayerController
    }

    public void UpdateAnimatorParameters(Vector3 movement, bool isJumping, float verticalVelocity)
    {
        bool isRunning = movement.magnitude > 0.1f;
        bool isFalling = verticalVelocity < 0 && !isJumping;

        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isJumping", isJumping);
        animator.SetBool("isFalling", isFalling);
    }
}
