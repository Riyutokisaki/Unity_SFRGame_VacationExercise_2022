using UnityEngine;
using System.Collections;
/// <summary>
/// 20220119�P�_����
/// </summary>
public class TaskList : MonoBehaviour
{
    #region ���
    [Header("A")]
    private Animal A_Cow;
    private Animal A_Sheep;
    public bool a_completion;
    [Header("B")]
    public bool b_completion;

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
    #region ��k
    /// <summary>
    /// ��ʪ�A�ճt�׬ۦP �hbool���F��TRUE�æ^�Ǭ۹�C#��T
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
