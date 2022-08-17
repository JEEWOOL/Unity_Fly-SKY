using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // 오브젝트 풀 크기
    public int poolSize = 10;

    // 오브젝트 풀 배열
    public List<GameObject> enemyObjectPool;

    // SpawnPoint
    public Transform[] spawnPoints;

    // 적 생성
    public GameObject enemyFactory;

    // 적 생성 최소시간
    float minTime = 0.5f;

    // 적 생성 최대시간
    float maxTime = 1.5f;

    // 생성시간
    float currentTime = 0;
    float createTime;

    public void Start()
    {
        //createTime = UnityEngine.Random.Range(minTime, maxTime);
        createTime = Random.Range(minTime, maxTime);

        // 오브젝트 풀을 적을 담을수 있는 크기로 만든다.
        enemyObjectPool = new List<GameObject>();

        // 오브젝트 풀에 넣을 적개수 만큼 반복한다.
        for(int i = 0; i < poolSize; i++)
        {
            // 적제작 공장에서 적을 생성한다.
            GameObject enemy = Instantiate(enemyFactory);

            // 적을 오브젝트 풀에 넣는다.
            enemyObjectPool.Add(enemy);

            // 비활성화
            enemy.SetActive(false);
        }
    }

    public void Update()
    {
        // 시간이 흐르다.
        currentTime += Time.deltaTime;

        // 일정시간이 되면
        if (currentTime > createTime)
        {
            // 오브젝트풀에서 적을 가져와서 사용
            GameObject enemy = enemyObjectPool[0];

            // 오브젝트풀에 적이 있다면
            if (enemyObjectPool.Count > 0)
            {
                // 적을 활성화 하고 싶다.
                enemy.SetActive(true);

                // 오브젝트풀에서 총알제거
                enemyObjectPool.Remove(enemy);

                // 랜덤으로 인덱스 선택
                int index = Random.Range(0, spawnPoints.Length);

                // 적 위치시키기
                enemy.transform.position = spawnPoints[index].position;                
            }

            createTime = Random.Range(minTime, maxTime);
            currentTime = 0;
        }
    }
}
