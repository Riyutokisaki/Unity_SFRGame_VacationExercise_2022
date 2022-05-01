using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 地面物品判定20220429
/// </summary>


public class GroundJudgment : MonoBehaviour
{

    #region 欄位

    #endregion
    public void OnGround(Transform selection)
    {
        var onarea=selection.GetComponent <area>().haveObstacle;
        if (onarea)
        {
            print("無法通過");
        }
        else
        {
            //呼叫主角移動
        }
    }
}
