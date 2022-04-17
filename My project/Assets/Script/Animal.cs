using UnityEngine;
using UnityEngine.AI;
/// <summary>
/// �ʪ����
/// 20220417 �K�[AI���
/// </summary>

public class Animal : MonoBehaviour
{
    #region ���
    [Header("����")]
    public Rigidbody RB;
    [Header("�ʵe")]
    public Animation AN;
    [Header("AI")]
    public NavMeshAgent agent;
    [Header("�w�]���ʦ�m")]
    public GameObject terget;
    private int patrol=0;
    public Vector3[] patrolPoint;
    public int coldTime = 20;
    private int cold;
    #endregion
    private void Start()
    {
        RB = GetComponent<Rigidbody>();//���o����
        AN = GetComponent<Animation>();//���o�ʵe����
        agent = GetComponent<NavMeshAgent>();//���oAI�P�w
        patrolPoint[0] = this.transform.position;
        cold = coldTime;
    }
    private void FixedUpdate()
    {
        if (cold == coldTime)
        {
            DefaultMove();
            cold = 0;
        }
        else cold++;
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }

    #region ��k
    //�ޯ�ϥ�
    public void SkillUse(float get) 
    {
        agent.speed = get;
    }
    //��m����
    private void DefaultMove()
    {

        for (patrol = 0; patrol < 2; patrol++)
        {

            agent.SetDestination(patrolPoint[patrol]);
            
            print("��F�I" + patrol);
        }
        if (patrol == 2)
        {
            agent.SetDestination(patrolPoint[patrol]);
            print("��F�I" + patrol);
            patrol = 0;
        }
        //��AI����w��m
    }
    #endregion
}