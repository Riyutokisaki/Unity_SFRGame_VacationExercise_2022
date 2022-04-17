using UnityEngine;
using UnityEngine.AI;
/// <summary>
/// 動物行動
/// 20220417 添加AI行動
/// </summary>

public class Animal : MonoBehaviour
{
    #region 欄位
    [Header("剛體")]
    public Rigidbody RB;
    [Header("動畫")]
    public Animation AN;
    [Header("AI")]
    public NavMeshAgent agent;
    [Header("預設移動位置")]
    public GameObject terget;
    private int patrol=0;
    public Vector3[] patrolPoint;
    public int coldTime = 20;
    private int cold;
    #endregion
    private void Start()
    {
        RB = GetComponent<Rigidbody>();//取得剛體
        AN = GetComponent<Animation>();//取得動畫控制
        agent = GetComponent<NavMeshAgent>();//取得AI判定
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

    #region 方法
    //技能使用
    public void SkillUse(float get) 
    {
        agent.speed = get;
    }
    //位置移動
    private void DefaultMove()
    {

        for (patrol = 0; patrol < 2; patrol++)
        {

            agent.SetDestination(patrolPoint[patrol]);
            
            print("到了點" + patrol);
        }
        if (patrol == 2)
        {
            agent.SetDestination(patrolPoint[patrol]);
            print("到了點" + patrol);
            patrol = 0;
        }
        //讓AI到指定位置
    }
    #endregion
}