using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private LayerMask groundPlayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] ObjectBehavior objectBehavior;
    private Animator animator;
    private bool isGrounded;
    private Rigidbody2D rb;
    private GameManager gameManager;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        objectBehavior.SpawnObject();
        gameManager = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        if (gameManager.IsGameOver()) return;
        HandleMovement();
        HandleJump();
        UpdateAnimation();
    }
    private void HandleMovement()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity=new Vector2(moveInput*moveSpeed,rb.velocity.y);
        if(moveInput>0) transform.localScale = new Vector3(1,1,1);
        else if (moveInput < 0) transform.localScale = new Vector3(-1, 1, 1);
    }
    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump")&&isGrounded)
        {
            rb.velocity=new Vector2(rb.velocity.x, jumpForce);
        }
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundPlayer);
    }
    private void UpdateAnimation()
    {
        bool isRunning=Mathf.Abs(rb.velocity.x)>0.1f;
        animator.SetBool("isRunning",isRunning);
        bool isJumping= !isGrounded;
        animator.SetBool("isJumping",isJumping);
    }
}
