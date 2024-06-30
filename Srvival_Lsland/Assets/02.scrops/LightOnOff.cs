using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnOff : MonoBehaviour
{
    public Light StarirLight;
    public AudioSource source;
    public AudioClip clip;
    void Start()
    {
        
    }
    // is Trigger ���� �� ��� �ϸ鼭 �浹 ����
    // �ϴ� �Լ� �ݹ� �Լ���� �� ������ ȣ�� �ϱ� ����
    private void OnTriggerEnter(Collider other) // ��� ������
    {
        if (other.gameObject.tag == "Player")
        {
            StarirLight.enabled = true;
        }
    }
    // �ݶ��̴� ������ ��� �Դٰ� ���� ��������
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StarirLight.enabled = false;
            source.PlayOneShot(clip,1.0f);
        }
    }

    void Update()
    {
        
    }
}
