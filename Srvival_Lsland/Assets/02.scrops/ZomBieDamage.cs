using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZomBieDamage : MonoBehaviour
{
    [Header("���۳�Ʈ")]
    public Rigidbody rb;
    public CapsuleCollider capCol;
    public Animator animator;
    public GameObject BloodEffect;

    [Header("���ú���")]
    public string playerTag = "Player";
    public string bulletTag = "BULLET";
    public string Hitstr = "HitTirgger";
    public string dieStr = "DieTrigger";
    public int hitCont = 0;
    public bool IsDie = false;

    [Header("UI ����")]
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
    {    // col.gameObject.tag == "Player" >> �����Ҵ�� �񱳸� ���ÿ� ��
        if (col.gameObject.CompareTag(playerTag))
        {
            rb.mass = 800f;     // �÷��̾ �ε�ĥ�� ������ ����
            rb.isKinematic = false;   // ������ �ְ�
            rb.freezeRotation = true; // �������� �߻� ���� �ʰ� ȸ�� ����
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
        //print("�¾ҳ�??");
        animator.SetTrigger(Hitstr);
                                        // ���� ��ġ - �߻� ��ġ = �Ÿ� 
        Vector3 fireNormal = (col.transform.position - transform.position).normalized;
        fireNormal = fireNormal.normalized;
        Quaternion rot = Quaternion.LookRotation(fireNormal);
        // LookRotation �Լ��� ���� ���� �޾Ƽ� ȸ������ �ٲپ� �ִ� ����� ����

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
        // �ݶ��̵� ��Ȱ��ȭ
        rb.isKinematic = true;
        IsDie = true;
        Destroy(gameObject, 5.0f);
        // 5���� �������.
    }
}
