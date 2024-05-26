using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDetector : MonoBehaviour
{
    // 충돌이 발생했을 때 호출되는 메소드
    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한 오브젝트가 Obstacle 태그를 가지고 있는지 확인
        if (collision.gameObject.CompareTag("obstacle"))
        {
            Debug.Log("Player가 obstacle에 닿았습니다!");
        }
    }

}
