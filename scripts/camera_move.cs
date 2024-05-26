using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_move: MonoBehaviour
{
    public float speed = 12f; // 움직이는 속도

    void Update()
    {
        // 카메라 위치를 현재 위치에 현재 x축 방향으로 speed만큼 이동한 위치로 설정
        transform.position += new Vector3(speed, 0f, 0f) * Time.deltaTime;
    }
}
