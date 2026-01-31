using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private float moveInputX;
    private float moveInputY;

    private bool isJumping;
    private bool isGrounded;
    private float jumpForce = 7f;
    private RaycastHit groundHit;
    private float moveSpeed = 50f;
    private Vector2 _moveVelocity;
    private float moveDamping = 5f;

    #region Movement


    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        moveInputX = UserInput.Instance.MoveInput.x;
        moveInputY = UserInput.Instance.MoveInput.y;

        if (moveInputX != 0f || moveInputY != 0f)
        {
            Vector3 moveDirection = new Vector3(moveInputX, 0, moveInputY).normalized * moveSpeed;
            rb.linearVelocity = Vector2.Lerp(_moveVelocity, moveDirection, moveDamping * Time.fixedDeltaTime);
            Debug.Log("Moving with velocity: " + rb.linearVelocity);
        }
        else
        {
            rb.linearVelocity = Vector2.Lerp(_moveVelocity, Vector2.zero, moveDamping * Time.fixedDeltaTime);
        }
    }

    private void Jump()
    {
        if(UserInput.Instance.JumpJustPressed && IsGrounded())
        {
            isJumping = true;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    private bool IsGrounded()
    {
        isGrounded = true;
        return Physics.Raycast(transform.position, Vector3.down, out groundHit, 1.1f);
    }

    #endregion
    
}