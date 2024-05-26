using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bear_move: MonoBehaviour
{
    public float moveSpeed = 12f;

    // Update is called once per frame
    void Update()
    {
        // 키 입력을 감지하여 움직임 제어

        transform.position += new Vector3(moveSpeed, moveSpeed, 0f) * Time.deltaTime;

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0f, -(moveSpeed+5), 0f) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(0f, 0f, +moveSpeed) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0f, 0f, -moveSpeed) * Time.deltaTime;
        }
    }
}
