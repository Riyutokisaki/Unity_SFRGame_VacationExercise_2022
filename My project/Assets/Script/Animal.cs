using UnityEngine;
using UnityEngine.AI;
/// <summary>
/// �ʪ����
/// 20220417 �K�[AI���
/// 20220418 �ޯ�ϥ�(�אּ�W�[���)�B�ͪ�����
/// 20220420 ���ȧPŪ
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
    public float speed;
    [Header("�w�]���ʦ�m")]
    public GameObject terget;
    private bool patrol=false;
    public Vector3[] patrolPoint;//�樫��m�I
    [Header("���ȸѨM")]
    public bool solving ;
    [Header("�ɤl�ĪG")]
    public ParticleSystem psSolving;
    #endregion
    private void Start()
    {
        RB = GetComponent<Rigidbody>();//���o����
        AN = GetComponent<Animation>();//���o�ʵe����
        agent = GetComponent<NavMeshAgent>();//���oAI�P�w
        patrolPoint[0] = this.transform.position;
        agent.SetDestination(patrolPoint[1]);
        //cold = 0;
        solving = false;
    }
    private void Update()
    {
        //speed = GetComponent<NavMeshAgent>().speed;//���o�t��
        if(solving)TaskSolving();//���ȧ���
        agent.speed=speed;//�]�m�t��
    }

    private void OnTriggerEnter(Collider other)
    {
        //�w�]���
        //print("�I��" + other);
        if (other.tag == "Finish"&& !solving)
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
        speed += get;
        agent.speed = speed;
        //�NAI���ʳt�קאּGET
    }

    public void TaskSolving()
    {
        agent.SetDestination(patrolPoint[3]);//���ʨ���I
        psSolving.Play();//�������
        if(transform.position==patrolPoint[3])speed = 0;//��F����
    }

    #endregion

}