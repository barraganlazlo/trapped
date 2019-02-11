using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{

    Rigidbody2D rb2d;
    bool jumpInputUp;
    bool jumpInputDown;
    bool jumpInput;
    bool isJumping;
    bool isRuning;
    float jumpTimeCounter;
    float actualSpeed;
    bool isFacingRight = true;
    [NonSerialized]
    public bool isGrounded;
    bool lastIsGrounded = true;
    float moveInput;

    #region Serialized Attributes
    public bool inverseDirection;
    public float walkSpeed = 10;
    public float runSpeed = 20;
    public float jumpForce = 10;
    public float jumpMaxDuration = 0.25f;
    public float checkRadius = 0.35f;
    public int particleNumber = 5;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public GameObject particles;
    #endregion

    #region MonoBehaviour API
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    //void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawSphere(groundCheck.position, checkRadius);
    //}
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        jumpInput = Input.GetButton("Jump");
        jumpInputDown = Input.GetButtonDown("Jump");
        jumpInputUp = Input.GetButtonUp("Jump");
        isRuning = Input.GetButton("Run");

        lastIsGrounded = isGrounded;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        if (isGrounded && !lastIsGrounded)
        {
            jumpTimeCounter = jumpMaxDuration;
            Instantiate(particles, groundCheck.position, Quaternion.identity,transform.parent);
        }
        if (isGrounded && jumpInputDown)
        {
            isJumping = true;
        }

        if (isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rb2d.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (jumpInputUp)
        {
            isJumping = false;
        }

        if (isFacingRight && moveInput < 0)
        {
            isFacingRight = false;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else if (!isFacingRight && moveInput > 0)
        {
            isFacingRight = true;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        if (isRuning)
        {
            actualSpeed = runSpeed;
        }else
        {
            actualSpeed = walkSpeed;
        }
        float f = moveInput * actualSpeed;
        if (inverseDirection)
        {
            f = -f;
        }
        rb2d.velocity = new Vector2(f, rb2d.velocity.y);
    }
    #endregion
}
