using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float jumpForce ,maxJumpForce = 10f; // ジャンプの上限

    [SerializeField]
    private Sprite jumpUp, jumpDown;

    private Animator animator;

    Python python;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        python = FindAnyObjectByType<Python>();
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        // 移動
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(new Vector2(speed, 0));
            transform.localScale = new Vector3(5, transform.localScale.y, transform.localScale.z);
            animator.SetBool("isRun", true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(new Vector2(-speed, 0));
            transform.localScale = new Vector3(-5, transform.localScale.y, transform.localScale.z);
            animator.SetBool("isRun", true);
        }

        // 速度の上限を制限
        if (rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }
        else if (rb.velocity.x < -maxSpeed)
        {
            rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
        }

        if(rb.velocity == Vector2.zero)
        {
            animator.SetBool("isRun", false);
        }
        // ジャンプ
        if (Input.GetKeyDown(KeyCode.Space))
=======
        Jump();
        JumpSprite();
    }

    private void Jump()
    {
        if (!canJump()) return;
        if (python.messages.TryDequeue(out string message) && message != null)
>>>>>>> Stashed changes
        {
            Debug.Log("Received from Python: " + message);
            // ここでmessageを使用した処理を行います
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            rb.AddForce(new Vector2(5, 9), ForceMode2D.Impulse);
            animator.enabled = false;
            transform.localScale = new Vector2(5, 5);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            rb.AddForce(new Vector2(-5, 9), ForceMode2D.Impulse);
            animator.enabled = false;
            transform.localScale = new Vector2(-5, 5);
        }
    }

    private bool canJump()
    {
        if (rb.velocity.y > 0.05f || rb.velocity.y < -0.05f) return false;
        animator.enabled = true;
        return true;
    }

    private void JumpSprite()
    {
        if (rb.velocity.y > 0.05)
        {
            animator.enabled = false;
            GetComponent<SpriteRenderer>().sprite = jumpUp;
        }
        if (rb.velocity.y < -0.05)
        {
            animator.enabled = false;
            GetComponent<SpriteRenderer>().sprite = jumpDown;
        }
    }
}
