using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 1. ĵ���� UI �� ī�޶� ó�� ����.
public class LookAtCamrers : MonoBehaviour
{
    public Transform mainCam;
    public Transform tr;
    void Start()
    {
        mainCam = Camera.main.transform;
        tr = GetComponent<Transform>();
    }

    void Update()
    {
        tr.LookAt(mainCam);
        // ĵ������ ����ī�޶� �Ĵٺ���.
    }
}
