using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    // Start is called before the first frame update
    private void Update()
    {
        transform.position = new Vector3(playerPos.position.x, playerPos.transform.position.y + 3, transform.position.z);
    }
}
