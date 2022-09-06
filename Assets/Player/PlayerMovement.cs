using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rg2d;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    [SerializeField]
    private float moveSpeed;

    public float jumpSpeed;

    [SerializeField]
    private LayerMask groundMask;

    private bool canJump = true;

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip jumpClip;

    void Start()
    {
        rg2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();

        audioSource = GetComponent<AudioSource>();
        

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Jump();
        Crouch();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        Vector2 horizontal = new Vector2(Input.GetAxis("Horizontal"), 0);

        if (horizontal.x != 0) animator.SetFloat("Speed", 1);
        else animator.SetFloat("Speed", 0);

        if (horizontal.x > 0) spriteRenderer.flipX = false;
        else if(horizontal.x < 0) spriteRenderer.flipX = true;

        gameObject.transform.Translate(horizontal * Time.fixedDeltaTime * moveSpeed);
    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            audioSource.clip = jumpClip;

            audioSource.Play();

            canJump = false;
            animator.SetBool("Jump", true);
            rg2d.AddForce(new Vector2(0, jumpSpeed * 100));
            StartCoroutine(JumpCoolDown());
        }

        else if (IsGrounded()) animator.SetBool("Jump", false);
    }

    private void Crouch()
    {

    }

    private bool IsGrounded()
    {
        if (Physics2D.BoxCast(transform.position, new Vector2(0.9f, 0.1f), 0, -transform.up, 0.7f, groundMask) && canJump) return true;
        else return false;
    }

    private IEnumerator JumpCoolDown()
    {
        yield return new WaitForSeconds(0.5f);
        canJump = true;
    }
}