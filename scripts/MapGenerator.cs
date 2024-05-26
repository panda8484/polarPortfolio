using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] prefabs;  // 배치할 프리팹들 (최소 9개 필요)
    public Transform player;      // 플레이어의 트랜스폼
    private float nextXThreshold = 100f;  // 첫 번째 기준 x좌표
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

        // 시작 시간 기록
        startTime = Time.time;

        // 기준 좌표에서 x 좌표가 288인 곳에 배치
        Vector3 position1 = new Vector3(288, basePosition.y, basePosition.z);
        InstantiateRandomPrefab(position1);

        // 기준 좌표에서 x 좌표가 388인 곳에 배치 (100만큼 더 큰 곳)
        Vector3 position2 = new Vector3(388, basePosition.y, basePosition.z); // 288 + 100
        InstantiateRandomPrefab(position2);

        // 기준 좌표에서 x 좌표가 488인 곳에 배치 (200만큼 더 큰 곳)
        Vector3 position3 = new Vector3(488, basePosition.y, basePosition.z); // 288 + 200
        InstantiateRandomPrefab(position3);

    }

    void Update()
    {
        
        // 플레이어의 x좌표가 nextXThreshold를 넘으면 프리팹 배치
        if (player.position.x >= nextXThreshold)
        {
            InstantiateRandomPrefab(spawnPosition);

            // 다음 기준 x좌표를 100씩 증가
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
            // 게임 시작 후 30초 동안: 1~3번째 프리팹 사용
            randomIndex = Random.Range(0, 3);
        }
        else if (elapsedTime <= 60)
        {
            // 게임 시작 후 30초 이후부터 60초까지: 4~6번째 프리팹 사용
            randomIndex = Random.Range(3, 6);
        }
        else if (elapsedTime <= 90)
        {
            // 게임 시작 후 60초 이후부터 90초까지: 7~9번째 프리팹 사용
            randomIndex = Random.Range(6, 9);
        }
        else
        {
            // 90초 이후: 1~9번째 프리팹 중 랜덤으로 사용
            randomIndex = Random.Range(0, 9);
        }

        GameObject prefabToInstantiate = prefabs[randomIndex];
        Instantiate(prefabToInstantiate, position, Quaternion.identity);
    }
}
