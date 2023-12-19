using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private Vector2 jumpForce = new Vector2(5,10);

    [SerializeField]
    private Sprite jumpUp, jumpDown;

    [SerializeField]
    private Text text;

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
        Jump();
        JumpSprite();
    }

    private void Jump()
    {
        if (!canJump()) return;
        if (python.messages.TryDequeue(out string message) && message != null)
        {
            Debug.Log("Pythonからの受信: " + message);
            // ここでmessageを使用した処理を行います
            text.text = message;
            if(message == "右")
            {
                RightJump();
            }
            else if(message == "左")
            {
                LeftJump();
            }
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            RightJump();
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            LeftJump();
        }
    }

    private void RightJump()
    {
            rb.AddForce(jumpForce, ForceMode2D.Impulse);
            animator.enabled = false;
            transform.localScale = new Vector2(5, 5);
    }

    private void LeftJump()
    {
            rb.AddForce(jumpForce, ForceMode2D.Impulse);
            animator.enabled = false;
            transform.localScale = new Vector2(-5, 5);
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