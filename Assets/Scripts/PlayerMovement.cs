using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    [SerializeField] private float jumpForce = 14f; // Giup bien private co the hien thi tren Unity Editor giong bien public nhung dam bao encapsulation
    [SerializeField] private float moveSpeed = 7f;
    private float dirX;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
         dirX = Input.GetAxisRaw("Horizontal");

        UpdateAnimation();


        rb.velocity = new Vector2 (dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        }

    }

    private void UpdateAnimation()
    {
        if (dirX < 0f)
        {
            animator.SetBool("running", true);
            spriteRenderer.flipX = true;
        }
        else if (dirX > 0f)
        {
            animator.SetBool("running", true);
            spriteRenderer.flipX = false;
        }
        else
        {
            animator.SetBool("running", false);
  
        }
    }
}
