using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startPlayer : MonoBehaviour
{
    // ȸ�� �ӵ��� �����ϴ� ����
    public float rotationSpeed = 100.0f;

    // �� �����Ӹ��� ȣ��Ǵ� �Լ�
    void Update()
    {
        // 'a' Ű�� ������ y������ ���� �������� ȸ��
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        }

        // 'd' Ű�� ������ y������ ��� �������� ȸ��
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
    }
}
