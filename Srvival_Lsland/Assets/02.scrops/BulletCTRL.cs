using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCTRL : MonoBehaviour
{
    public float speed = 1500f;
    public Rigidbody rb;
    public int damage = 20;
    void Start()
    {
                   // Vector3.forward �۷ι� ��ǥ
        rb.AddForce(transform.forward * speed);
        // ���� ��ǥ�� ���ǵ� ��ŭ ������.
        Destroy(this.gameObject, 3.0f);
        // �ڱ��ڽ��� ������Ʈ�� 3���Ŀ� �޸𸮿���
        // �����Ѵ�
    }
}
