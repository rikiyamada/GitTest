using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float speed = 5.0f; // 移動速度
    public float distance = 9.0f; // 移動する距離

    private bool moveRight = false; // 最初に左に移動するように変更
    private float initialPosition;
    private float targetPosition;

    void Start()
    {
        initialPosition = transform.position.x;
        targetPosition = initialPosition - distance; // 初期位置から9マス左に移動
    }

    void Update()
    {
        if (moveRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);

            if (transform.position.x >= initialPosition)
            {
                moveRight = false;
            }
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);

            if (transform.position.x <= targetPosition)
            {
                moveRight = true;
            }
        }
    }
}
