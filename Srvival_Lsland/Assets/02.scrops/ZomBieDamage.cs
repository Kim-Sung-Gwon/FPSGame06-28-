using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZomBieDamage : MonoBehaviour
{
    [Header("컴퍼넌트")]
    public Rigidbody rb;
    public CapsuleCollider capCol;
    public Animator animator;
    public GameObject BloodEffect;

    [Header("관련변수")]
    public string playerTag = "Player";
    public string bulletTag = "BULLET";
    public string Hitstr = "HitTirgger";
    public string dieStr = "DieTrigger";
    public int hitCont = 0;
    public bool IsDie = false;

    [Header("UI 관련")]
    public Image hpBar;
    public Text hpTxt;
    public int maxHp = 100;
    public int HpInit = 0;
    FireCTRL FireCtrl;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        capCol = GetComponent<CapsuleCollider>();
        animator = GetComponent<Animator>();
        FireCtrl = GameObject.FindWithTag("Player").GetComponent<FireCTRL>();
        HpInit = maxHp;
        hpBar.color = Color.green;
    }
    private void OnCollisionEnter(Collision col)
    {    // col.gameObject.tag == "Player" >> 동적할당과 비교를 동시에 함
        if (col.gameObject.CompareTag(playerTag))
        {
            rb.mass = 800f;     // 플레이어가 부딪칠때 무개를 높임
            rb.isKinematic = false;   // 물리력 있게
            rb.freezeRotation = true; // 물리력이 발생 하지 않게 회전 제한
        }

        else if (col.gameObject.CompareTag(bulletTag))
        {
            HitInfo(col);
            
            HpInit -= col.gameObject.GetComponent<BulletCTRL>().damage;
            hpBar.fillAmount = (float)HpInit / (float)maxHp;
            Debug.Log(HpInit);
            
            hpTxt.text = $"HP: <color=#ff0000>{HpInit.ToString()}" +
            $"</color>";
            
            if (hpBar.fillAmount <= 0.3f)
                hpBar.color = Color.red;
            
            else if (hpBar.fillAmount <= 0.5f)
                    hpBar.color = Color.yellow;
            
            if (HpInit <= 0)
            {
                ZomBieDie();
            }
        }
    }

    private void HitInfo(Collision col)
    {
        Destroy(col.gameObject);
        //print("맞았나??");
        animator.SetTrigger(Hitstr);
                                        // 맞은 위치 - 발사 위치 = 거리 
        Vector3 fireNormal = (col.transform.position - transform.position).normalized;
        fireNormal = fireNormal.normalized;
        Quaternion rot = Quaternion.LookRotation(fireNormal);
        // LookRotation 함수는 벡터 값을 받아서 회전으로 바꾸어 주는 기능을 가짐

        //Vector3 hitPos = col.transform.position;
        //Quaternion rot = Quaternion.FromToRotation(-Vector3.forward, hitPos);
        //var blood = Instantiate(BloodEffect, hitPos, rot);

        var blood = Instantiate(BloodEffect, col.transform.position, rot);
        Destroy(blood, Random.Range(0.8f, 1.2f));
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag(playerTag))
        {
            rb.mass = 75f;
            rb.freezeRotation = true;
        }
    }
    void ZomBieDie()
    {
        animator.SetTrigger(dieStr);
        capCol.enabled = false;
        // 콜라이드 비활성화
        rb.isKinematic = true;
        IsDie = true;
        Destroy(gameObject, 5.0f);
        // 5초후 사라진다.
    }
}
