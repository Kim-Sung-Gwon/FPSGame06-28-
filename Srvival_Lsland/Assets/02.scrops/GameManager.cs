using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Enemy �� �׾�� ������ ���Ҿ� ���� ��ü�� �ƿ츣�� ��� �� �����ϴ� Ŭ����
// 1. �� ������   2. �¾ ��ġ   3. �ð� ����   4. ��� ���� �¾��
public class GameManager : MonoBehaviour
{
    public GameObject zomdiePrefab;
    public Transform[] points;
    private float timePrev;
    private float spawnTime = 3.0f;
    private int maxCount = 10;

    void Start()
    {         // ���̶�Ű���� SpawnPoints ��� ������Ʈ ���� ã�´�.
              // �ڱ��ڽ� �����ؼ� ����������Ʈ�� Ʈ������ ���� Points �迭�� �� �ִ´�.
              // ���� �Ҵ��� �̷����� �ִ�.
        points = GameObject.Find("SpawnPoints").GetComponentsInChildren<Transform>();
        timePrev = Time.time;
    }

    void Update()
    {    // ���� �ð� - ���� �ð� = ���� �ð�
        if (Time.time - timePrev >= spawnTime)
        {           // ���̶�Ű���� ZOMBIE �±׸� ���� �͵��� ������ ī��Ʈ �ؼ� �ѱ�
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
