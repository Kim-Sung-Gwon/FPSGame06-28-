using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonCtrl : MonoBehaviour
{
    [Header("컨퍼넌트")]
    public NavMeshAgent agent;
    public Transform Player;
    public Transform Skeleton;
    public Animator animator;
    public SkeletonDamege damege;
    [Header("관련변수")]
    public float AttackDist = 3.0f;
    public float traceDist = 20f;

    void Start()
    {
        
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        Skeleton = transform; 
        Player = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
        damege = GetComponent<SkeletonDamege>();
    }

    void Update()
    {
        if (damege.IsDie)return;

        float distance = Vector3.Distance(Skeleton.position, Player.position);
        if (distance < AttackDist)
        {
            agent.isStopped = true;
            animator.SetBool("IsAttack", true);
            Debug.Log("공격");
        }
        else if (distance <= traceDist)
        {
            animator.SetBool("IsAttack", false);
            animator.SetBool("IsTrace", true);
            agent.isStopped = false;
            agent.destination = Player.position;
            Debug.Log("추적 !!");
        }
        else
        {
            animator.SetBool("IsTrace", false);
            agent.isStopped = false;
            Debug.Log("추적 범위 벗어남 !");
        }
    }
}
