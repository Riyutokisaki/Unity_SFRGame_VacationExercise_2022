using UnityEngine;
using UnityEngine.AI;
/// <summary>
/// 動物行動
/// 20220417 添加AI行動
/// 20220418 技能使用(改為增加減少)、生物移動
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
    private bool patrol=false;
    public Vector3[] patrolPoint;//行走位置點
    public int coldTime = 20;//設定冷卻時間
    //private int cold;//實際冷卻時間
    #endregion
    private void Start()
    {
        RB = GetComponent<Rigidbody>();//取得剛體
        AN = GetComponent<Animation>();//取得動畫控制
        agent = GetComponent<NavMeshAgent>();//取得AI判定
        patrolPoint[0] = this.transform.position;
        agent.SetDestination(patrolPoint[1]);
        //cold = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        print("碰到" + other);
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

    #region 方法
    //技能使用
    public void SkillUse(float get) 
    {
        agent.speed += get;//將AI移動速度改為GET
    }
    //位置移動


   
    #endregion
    
}