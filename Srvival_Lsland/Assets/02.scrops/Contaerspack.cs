using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contaerspack : MonoBehaviour
{
    public GameObject SparkPrefab;
    public AudioClip SparkClip;
    public AudioSource surce;
    //public FireCTRL firePos;

    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "BULLET")
        {
            Destroy(col.gameObject);
            surce.PlayOneShot(SparkClip, 1.0f);
            ////  what , where �浹�� ��ġ
            //Vector3 hitpos = col.transform.position;
            //// ���� ��ġ - �߻���ġ = �Ÿ�
            //Vector3 firePosnormal = hitpos - FireCTRL.firePos.position;
            //firePosnormal = firePosnormal.normalized;  // ����ȭ ������
            //var spark = Instantiate(SparkPrefab, hitpos, rot);

            var spark = Instantiate(SparkPrefab, col.transform.position, Quaternion.identity);
            Destroy(spark, 2.0f);
        }
    }

    void Update()
    {
        
    }
}
