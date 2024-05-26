using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UWPlayerMove : MonoBehaviour
{
    public float moveSpeed = 12f;

    // Update is called once per frame
    void Update()
    {
        // �⺻ �̵�
        Vector3 newPosition = transform.position;

        // ���ǿ� ���� �̵� ����
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
        // Ű �Է��� �����Ͽ� ������ ����

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
        Debug.Log("����!");
    }
}
