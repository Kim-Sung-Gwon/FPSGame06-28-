using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Enemy 가 테어나는 로직과 더불어 게임 전체를 아우르는 기능 즉 조정하는 클래스
// 1. 적 프리팹   2. 태어날 위치   3. 시간 간격   4. 몇마리 까지 태어날지
public class GameManager : MonoBehaviour
{
    public GameObject zomdiePrefab;
    public Transform[] points;
    private float timePrev;
    private float spawnTime = 3.0f;
    private int maxCount = 10;

    void Start()
    {         // 하이라키에서 SpawnPoints 라는 오브젝트 명을 찾는다.
              // 자기자신 보함해서 하위오브젝트의 트랜스폼 들을 Points 배열에 다 넣는다.
              // 동적 할당이 이러나고 있다.
        points = GameObject.Find("SpawnPoints").GetComponentsInChildren<Transform>();
        timePrev = Time.time;
    }

    void Update()
    {    // 현재 시간 - 과거 시간 = 지난 시간
        if (Time.time - timePrev >= spawnTime)
        {           // 하이라키에서 ZOMBIE 태그를 가진 것들의 갯수를 카운트 해서 넘김
            int zombieCount = GameObject.FindGameObjectsWithTag("ZOMBIE").Length;
            if (zombieCount < maxCount)
            {
                int randPos = Random.Range(1, points.Length);
                Instantiate(zomdiePrefab, points[randPos].position,
                    points[randPos].rotation);
                timePrev = Time.time;
            }
        }
    }
}
