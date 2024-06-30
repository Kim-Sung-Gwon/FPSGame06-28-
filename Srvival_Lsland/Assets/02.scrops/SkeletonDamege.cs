using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeletonDamege : MonoBehaviour
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
    public Image HPBar;
    public Text hpTxt;
    public int maxHp = 100;
    public int HpInit = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        capCol = GetComponent<CapsuleCollider>();
        animator = GetComponent<Animator>();
        HpInit = maxHp;
        HPBar.color = Color.green;
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag(playerTag))
        {
            rb.mass = 800f;
            rb.isKinematic = false;
            rb.freezeRotation = true;
        }

        else if (col.gameObject.CompareTag(bulletTag))
        {
            HitInfo(col);

            HpInit -= col.gameObject.GetComponent<BulletCTRL>().damage;
            HPBar.fillAmount = (float)HpInit / (float)maxHp;
            Debug.Log(HpInit);

            hpTxt.text = $"HP: <color=#ff0000>{HpInit.ToString()}" +
            $"</color>";

            if (HPBar.fillAmount <= 0.3f)
                HPBar.color = Color.red;

            else if (HPBar.fillAmount <= 0.5f)
                HPBar.color = Color.yellow;

            if (HpInit <= 0)
            {
                SkeletonDie();
            }
        }
    }

    private void HitInfo(Collision col)
    {
        Destroy(col.gameObject);
        animator.SetTrigger(Hitstr);
        Vector3 hitPos = col.transform.position;
        Quaternion rot = Quaternion.FromToRotation(-Vector3.forward, hitPos);
        var blood = Instantiate(BloodEffect, hitPos, rot);
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

    private void SkeletonDie()
    {
        animator.SetTrigger("DieTrigger");
        capCol.enabled = false;
        rb.isKinematic = true;
        IsDie = true;
    }
}
