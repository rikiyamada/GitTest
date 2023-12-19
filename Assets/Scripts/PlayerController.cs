using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private Sprite jumpUp, jumpDown;
    [SerializeField] private Text VoiceText, VolumeText;

    private Animator animator;
    private Vector2 jumpVec = new Vector2(5, 9), jumpForce;
    private bool isJumping = false;
    Python python;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        python = FindAnyObjectByType<Python>(); // Python クラスに関する部分はコメントアウトされているため、インスタンス化できるようにしてください
    }

    void Update()
    {
        Jump();
        JumpSprite();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RightJump();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LeftJump();
        }
    }

    private void RightJump()
    {
        jumpForce = new Vector2(jumpVec.x, jumpVec.y);
        rb.velocity = Vector2.zero;
        rb.AddForce(jumpForce, ForceMode2D.Impulse);
        animator.enabled = false;
        transform.localScale = new Vector2(5, 5);
    }

    private void LeftJump()
    {
        jumpForce = new Vector2(-jumpVec.x, jumpVec.y);
        rb.velocity = Vector2.zero;
        rb.AddForce(jumpForce, ForceMode2D.Impulse);
        animator.enabled = false;
        transform.localScale = new Vector2(-5, 5);
    }

    private void JumpSprite()
    {
        if (rb.velocity.y > 0.05)
        {
            animator.enabled = false;
            GetComponent<SpriteRenderer>().sprite = jumpUp;
        }
        else if (rb.velocity.y < -0.05)
        {
            animator.enabled = false;
            GetComponent<SpriteRenderer>().sprite = jumpDown;
        }
        else
        {
            animator.enabled = true;
        }
    }
}
