using UnityEngine;
/// <summary>
/// �ϰ줺�O�_���ͪ�20220501
/// </summary>
public class area : MonoBehaviour
{
    #region ���
    public bool haveObstacle;
    [Header("�����d��")]
    public Vector3 detectionRange=Vector3.one;
    public Vector3 detectionHight;

    #endregion
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0, 1,.5f);//�P�_�ϳ]�m���Ŧ�
        Gizmos.DrawCube(transform.position+detectionHight, detectionRange);//�����Ϧ�m
    }

    private void Update()
    {
        CheckArea();
    }
    #region ��k
    private void CheckArea()//�˴������O�_���F��
    {
        haveObstacle = false;//�C�V�˴��e������

        Collider[] hit = Physics.OverlapBox(transform.position + detectionHight, detectionRange/2, Quaternion.Euler(0, 0, 0),6);//(�����I�A�j�p�A����A�ϼh�X)
        int? hitHave = hit?.Length;
        if(hitHave!=null)//�Y�������F��
        {
            //print(hit[0].name + "�I��" + transform.name);
            haveObstacle = true;//����ê���}��
            hit = null;//�R���������~

        }
    }
    #endregion
}
