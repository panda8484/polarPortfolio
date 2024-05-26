using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startPlayer : MonoBehaviour
{
    // 회전 속도를 설정하는 변수
    public float rotationSpeed = 100.0f;

    // 매 프레임마다 호출되는 함수
    void Update()
    {
        // 'a' 키가 눌리면 y축으로 음수 방향으로 회전
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        }

        // 'd' 키가 눌리면 y축으로 양수 방향으로 회전
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
    }
}
