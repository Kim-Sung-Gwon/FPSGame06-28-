using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 1. 캔버스 UI 가 카메라를 처다 본다.
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
        // 캔버스가 메인카메라를 쳐다본다.
    }
}
