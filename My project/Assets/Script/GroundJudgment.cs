using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �a�����~�P�w20220429
/// </summary>


public class GroundJudgment : MonoBehaviour
{

    #region ���

    #endregion
    public void OnGround(Transform selection)
    {
        var onarea=selection.GetComponent <area>().haveObstacle;
        if (onarea)
        {
            print("�L�k�q�L");
        }
        else
        {
            //�I�s�D������
        }
    }
}
