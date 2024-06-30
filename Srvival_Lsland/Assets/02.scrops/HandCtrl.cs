using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCtrl : MonoBehaviour
{
    public Animation ComBatSGAni;
    public Light flacshLight;
    public AudioClip flacshSound;
    public AudioSource A_source;
    public bool isRun = false;
    void Start() // ���� ���� �� ȣ�� �Ǵ� ����
    {
        
    }

    void Update()  // ���� ���� �� ��� ȣ�� �Ǵ� ����
    {
        GunCtrl();
        FlashLightOnOff();
    }

    private void FlashLightOnOff()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            flacshLight.enabled = !flacshLight.enabled;
            A_source.PlayOneShot(flacshSound, 1.0f);
            // �Ҹ�����, �Ҹ� ����
        }
    }

    private void GunCtrl()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            ComBatSGAni.Play("running");
            isRun = true;
        }

        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            ComBatSGAni.Play("runStop");
            isRun = false;
        }
    }
}
