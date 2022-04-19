using UnityEngine;
/// <summary>
/// 20220119判斷任務
/// </summary>
public class TaskList : MonoBehaviour
{
    #region 欄位
    [Header("A")]
    Animal A_Cow;
    Animal A_Sheep;
    #endregion
    private void Start()
    {
        #region A
        A_Cow = GameObject.Find("CowBlW").GetComponent<Animal>();
        A_Sheep = GameObject.Find("SheepWhite").GetComponent<Animal>();

        #endregion
    }
    void Update()
    {
        A_AnimalStop();
    }
    #region 方法
    /// <summary>
    /// 當動物A組速度相同 則bool為達成TRUE並回傳相對C#資訊
    /// </summary>
    private void A_AnimalStop()
    {
        if (A_Cow.speed == A_Sheep.speed)
        {
            A_Sheep.solving = true;
            A_Cow.solving = true;
        }
        else
        {
            A_Sheep.solving = false;
            A_Cow.solving = false;
        }
    }
    #endregion
}
