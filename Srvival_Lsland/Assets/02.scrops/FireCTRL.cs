using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCTRL : MonoBehaviour
{
    [Header("���۳�Ʈ��")]
    // �Ѿ� ������Ʈ
    public GameObject bulletPrefab;
    public Transform FirePos;
    // �߻� ��ġ
    public Animation fireAni;
    public AudioSource source;
    public AudioClip fireclip;
    public ParticleSystem muzzleFlash;
    [Header("���� ������")]
    private float fireTime;
    public HandCtrl handCtrl;
    public int bulletCount = 0;
    bool isReload = false;
    // Start is called before the first frame update
    void Start()
    {
        handCtrl = this.gameObject.GetComponent<HandCtrl>();
        fireTime = Time.time;
        muzzleFlash.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        #region �ѹ߾� �߻��ϴ� ����
        // ���콺 ���� ��ư ������ �� 0
        // 1 ��  ������ 2�� ���콺 �ٹ�ư
        //if (Input.GetMouseButtonDown(0))
        //    Fire();
        #endregion
        #region �Ѿ� �߻縦 ����� �ϴ� ����
        if (Input.GetMouseButton(0))
        {
            if (Time.time - fireTime > 0.2f)
            {
                if(!handCtrl.isRun && !isReload)
                Fire();
                fireTime = Time.time;
                
            }
        }
        #endregion
        #region ���콺 ���� ��ư�� ����� ��
        //if (Input.GetMouseButtonUp(0))
        //{
        //    muzzleFlash.Stop();
        //}
        #endregion
    }
    void Fire() // �Ѿ� �߻� �Լ�
    {
        ++bulletCount;
        // ������Ʈ ���� �Լ�
        Instantiate(bulletPrefab, FirePos.position,
            FirePos.rotation);
        source.PlayOneShot(fireclip,1.0f);
        fireAni.Play("fire");
        muzzleFlash.Play();
        Invoke("MuzzleFlashDisable",0.03f);
        // �޼��� �� string ��  , �ð�
        // ���ϴ� �ð� ���� ��ŭ �޼��带 ȣ��
        if (bulletCount == 10)
        {
            // ��Ÿ �ڷ�ƾ
            // ���� �� �����ڰ� ���ϴ� �������� ������� �� �� ���
            StartCoroutine(Reload());
            // �Ʒ� Reload() ȣ��
        }
    }
    IEnumerator Reload()
    {   
        isReload = true;
        fireAni.Play("pump1"); // ���ε� �ִϸ��̼� ���
                               // 0.8�� �Ŀ�
        yield return new WaitForSeconds(0.5f);
        bulletCount = 0;
        isReload = false;
    }
    void MuzzleFlashDisable()
    {
        muzzleFlash.Stop();
    }
}
