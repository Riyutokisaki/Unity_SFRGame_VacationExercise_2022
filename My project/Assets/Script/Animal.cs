using UnityEngine;
using UnityEngine.AI;
/// <summary>
/// �ʪ����
/// 20220417 �K�[AI���
/// 20220418 �ޯ�ϥ�(�אּ�W�[���)�B�ͪ�����
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
    private bool patrol=false;
    public Vector3[] patrolPoint;//�樫��m�I
    public int coldTime = 20;//�]�w�N�o�ɶ�
    //private int cold;//��ڧN�o�ɶ�
    #endregion
    private void Start()
    {
        RB = GetComponent<Rigidbody>();//���o����
        AN = GetComponent<Animation>();//���o�ʵe����
        agent = GetComponent<NavMeshAgent>();//���oAI�P�w
        patrolPoint[0] = this.transform.position;
        agent.SetDestination(patrolPoint[1]);
        //cold = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        print("�I��" + other);
        if (other.tag == "Finish")
        {
            if (patrol)
            {
                agent.SetDestination(patrolPoint[1]);
                patrol = false;
            }
            else
            { 
                agent.SetDestination(patrolPoint[2]);
                patrol = true;

            }
        
        }
    }

    #region ��k
    //�ޯ�ϥ�
    public void SkillUse(float get) 
    {
        agent.speed += get;//�NAI���ʳt�קאּGET
    }
    //��m����


   
    #endregion
    
}