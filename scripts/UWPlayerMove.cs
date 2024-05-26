using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UWPlayerMove : MonoBehaviour
{
    public float moveSpeed = 12f;

    // Update is called once per frame
    void Update()
    {
        // 기본 이동
        Vector3 newPosition = transform.position;

        // 조건에 따른 이동 제어
        if (-7 <= newPosition.x && newPosition.x <= -5)
        {
            Stop();

            if (Input.GetKey(KeyCode.W))
            {
                KeepGo();
            }
        }
        else if (27 <= newPosition.x && newPosition.x <= 29)
        {
            Stop();

            if (Input.GetKey(KeyCode.S))
            {
                KeepGo();
            }
        }
        else if (76 <= newPosition.x && newPosition.x <= 78)
        {
            Stop();
            if (Input.GetKey(KeyCode.D))
            {
                KeepGo();
            }
        }
        else if (118 <= newPosition.x && newPosition.x <= 120)
        {
            Stop();
            if (Input.GetKey(KeyCode.A))
            {
                KeepGo();
            }
        }
        else
        {
            KeepGo();
        }

    }

    public void KeepGo()
    {
        // 키 입력을 감지하여 움직임 제어

        transform.position += new Vector3(moveSpeed, moveSpeed, 0f) * Time.deltaTime;

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0f, -(moveSpeed + 5), 0f) * Time.deltaTime;
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

    public void Stop()
    {
        transform.position += new Vector3(0f, 0f, 0f) * Time.deltaTime;
        Debug.Log("멈춤!");
    }
}
