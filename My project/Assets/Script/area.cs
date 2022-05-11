using UnityEngine;
using System;////Array.IndexOf�ϥ�
/// <summary>
/// �ϰ줺�O�_���ͪ�20220501
/// </summary>
public class area : MonoBehaviour
{
    #region ���
    [Header("��ê���P�w")]
    public bool haveObstacle;
    [Header("�����d��")]
    public Vector3 detectionRange=Vector3.one;
    public Vector3 detectionHight;
    [Header("Ĳ�I�d�����")]
    public bool gizmosOn;
    [Header("�L�k�q���ê��TAG")]
    public string[] draggingTag;

    #endregion
   
    private void OnDrawGizmos()
    {
        if (gizmosOn)
        {
            Gizmos.color = new Color(0, 0, 1, .2f);//�P�_�ϳ]�m���Ŧ�
            Gizmos.DrawCube(transform.position + detectionHight, detectionRange);//�����Ϧ�m
        }
    }

    private void Update()
    {
       
        CheckArea();
    }
    #region ��k
    public void CheckArea()//�˴������O�_���F��
    {
        Collider[] hit = Physics.OverlapBox(transform.position + detectionHight, detectionRange/2, Quaternion.identity);//(�����I�A�j�p�A����A�ϼh�X)
        haveObstacle = false;
        int i = 0;
        while (i < hit.Length)//�Yi�p��hit�̤j��
        {
            print(transform.name+"Hit : " + hit[i].name+ hit[i].tag + ",��"+ i+"����,T�P�w"+ Array.IndexOf(draggingTag, hit[i]));
            if (Array.IndexOf(draggingTag, hit[i].tag) > -1) haveObstacle = true;//����ê���}��
            else haveObstacle = false;
            i++;
        }
    }
    #endregion
}
