using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_move: MonoBehaviour
{
    public float speed = 12f; // �����̴� �ӵ�

    void Update()
    {
        // ī�޶� ��ġ�� ���� ��ġ�� ���� x�� �������� speed��ŭ �̵��� ��ġ�� ����
        transform.position += new Vector3(speed, 0f, 0f) * Time.deltaTime;
    }
}
