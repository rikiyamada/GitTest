using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float maxSpeed = 5f;

    [SerializeField]
    private float jumpForceMultiplier = 15f; // ジャンプ力の倍率

    [SerializeField]
    private float maxJumpForce = 10f; // ジャンプの上限

    private float jumpStartTime; // ジャンプボタンを押し始めた時間

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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
        {
            jumpStartTime = Time.time;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            float jumpDuration = Time.time - jumpStartTime; // キーを押し続けた時間を計算
            float jumpForce = Mathf.Clamp(jumpDuration * jumpForceMultiplier, 0, maxJumpForce);
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
}
