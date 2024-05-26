using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] prefabs;  // ��ġ�� �����յ� (�ּ� 9�� �ʿ�)
    public Transform player;      // �÷��̾��� Ʈ������
    private float nextXThreshold = 100f;  // ù ��° ���� x��ǥ
    public Vector3 basePosition = new Vector3(228, -71, 15);
    private float startTime;
    private Vector3 spawnPosition = new Vector3(588f, -71, 15);

    void Start()
    {
        if (prefabs.Length < 9)
        {
            Debug.LogError("There must be at least 9 prefabs assigned.");
            return;
        }

        // ���� �ð� ���
        startTime = Time.time;

        // ���� ��ǥ���� x ��ǥ�� 288�� ���� ��ġ
        Vector3 position1 = new Vector3(288, basePosition.y, basePosition.z);
        InstantiateRandomPrefab(position1);

        // ���� ��ǥ���� x ��ǥ�� 388�� ���� ��ġ (100��ŭ �� ū ��)
        Vector3 position2 = new Vector3(388, basePosition.y, basePosition.z); // 288 + 100
        InstantiateRandomPrefab(position2);

        // ���� ��ǥ���� x ��ǥ�� 488�� ���� ��ġ (200��ŭ �� ū ��)
        Vector3 position3 = new Vector3(488, basePosition.y, basePosition.z); // 288 + 200
        InstantiateRandomPrefab(position3);

    }

    void Update()
    {
        
        // �÷��̾��� x��ǥ�� nextXThreshold�� ������ ������ ��ġ
        if (player.position.x >= nextXThreshold)
        {
            InstantiateRandomPrefab(spawnPosition);

            // ���� ���� x��ǥ�� 100�� ����
            nextXThreshold += 100f;
            spawnPosition.x += 100f;
        }
    }

    void InstantiateRandomPrefab(Vector3 position)
    {
        float elapsedTime = Time.time - startTime;
        int randomIndex;

        if (elapsedTime <= 30)
        {
            // ���� ���� �� 30�� ����: 1~3��° ������ ���
            randomIndex = Random.Range(0, 3);
        }
        else if (elapsedTime <= 60)
        {
            // ���� ���� �� 30�� ���ĺ��� 60�ʱ���: 4~6��° ������ ���
            randomIndex = Random.Range(3, 6);
        }
        else if (elapsedTime <= 90)
        {
            // ���� ���� �� 60�� ���ĺ��� 90�ʱ���: 7~9��° ������ ���
            randomIndex = Random.Range(6, 9);
        }
        else
        {
            // 90�� ����: 1~9��° ������ �� �������� ���
            randomIndex = Random.Range(0, 9);
        }

        GameObject prefabToInstantiate = prefabs[randomIndex];
        Instantiate(prefabToInstantiate, position, Quaternion.identity);
    }
}
