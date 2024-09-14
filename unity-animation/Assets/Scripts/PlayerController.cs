using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float fallThreshold = -10f;
    private Vector3 startPosition;

    private Rigidbody rb;
    private bool isGrounded;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();

        if (animator == null)
        {
            Debug.LogError("Animator not found on any child GameObject.");
        }

        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        startPosition = transform.position;
    }

    private void FixedUpdate()
    {
        CheckGroundStatus();
    }

    private void Update()
    {
        MovePlayer();
        Jump();
        CheckFalling();
    }

    private void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (movement.magnitude > 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
            rb.velocity = new Vector3(movement.x * moveSpeed, rb.velocity.y, movement.z * moveSpeed);

            if (animator != null)
            {
                animator.SetBool("IsRunning", true);
            }
        }
        else
        {
            if (animator != null)
            {
                animator.SetBool("IsRunning", false);
            }
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;

            if (animator != null)
            {
                animator.SetTrigger("Jump");
            }
        }
    }

    private void CheckFalling()
    {
        if (transform.position.y < fallThreshold)
        {
            Respawn();

            if (animator != null)
            {
                animator.SetTrigger("Fall");
            }
        }
    }

    private void Respawn()
    {
        transform.position = startPosition;
        rb.velocity = Vector3.zero;
    }

    private void CheckGroundStatus()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
