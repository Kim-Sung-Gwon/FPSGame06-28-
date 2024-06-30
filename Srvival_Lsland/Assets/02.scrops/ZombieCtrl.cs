using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieCtrl : MonoBehaviour
{  // Attribute ��Ʃ�� ��Ʈ  >> �����ڰ� ���� ��ǻ�Ͱ� �о ����
    [Header("���۳�Ʈ")]
    public NavMeshAgent agent;      // ������ ����� ã�� �׺� ���۳�Ʈ
    public Transform Player;        // �Ÿ��� ��� ����
    public Transform thisZomBie;
    public Animator animator;
    public ZomBieDamage damege;
    [Header("���ú���")]
    public float attackDist = 3.0f; // ���� ����
    public float traceDist = 20f;   // ���� ����
    

    void Start()
    {   // �ڱ� �ڽ� ���� ������Ʈ �ȿ� �ִ� NavmeshAgent ���۳�Ʈ ����
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        // C# ���־� ��Ʃ��� >> agent = new NavMeshAgent();
        thisZomBie = transform;
        Player = GameObject.FindWithTag("Player").transform;
        //  ���̶�Ű�ȿ� �ִ� ���ӿ�����Ʈ�� �±׸� �о �����´�.
        animator = GetComponent<Animator>();
        damege = GetComponent<ZomBieDamage>();
       
    }

    
    void Update()
    {   // �Ÿ��� ���. 
        if (damege.IsDie) return;
        float distance = Vector3.Distance(thisZomBie.position, Player.position);
        // ���� �������� �������� �ʰ� ����
        if (distance < attackDist)
        {
            agent.isStopped = true;
            animator.SetBool("IsAttack", true);
            Debug.Log("����");
        }
        else if (distance <= traceDist)
        {
            animator.SetBool("IsAttack", false);
            animator.SetBool("IsTrace", true);
            agent.isStopped = false;
            agent.destination = Player.position;
            Debug.Log("���� !!");
        }
        else
        {
            animator.SetBool("IsTrace", false);
            agent.isStopped = false;
            Debug.Log("���� ���� ��� !");
        }
    }
}
