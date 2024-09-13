using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
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
        bool isJumping = Input.GetKeyDown(KeyCode.Space);

        bool isRunning = Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f || Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f;

        animator.SetBool("isJumping", isJumping);
        animator.SetBool("isRunning", isRunning);
    }
}
