using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDetector : MonoBehaviour
{
    // �浹�� �߻����� �� ȣ��Ǵ� �޼ҵ�
    private void OnCollisionEnter(Collision collision)
    {
        // �浹�� ������Ʈ�� Obstacle �±׸� ������ �ִ��� Ȯ��
        if (collision.gameObject.CompareTag("obstacle"))
        {
            Debug.Log("Player�� obstacle�� ��ҽ��ϴ�!");
        }
    }

}
