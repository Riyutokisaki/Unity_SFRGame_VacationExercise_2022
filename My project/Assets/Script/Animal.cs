using UnityEngine;

public class Animal : MonoBehaviour
{
    #region ���
    //[Header("���ʳt��")]
    [Header("����")]
    public Rigidbody RB;

    #endregion
    private void Start()
    {
        RB = GetComponent<Rigidbody>();//���o����
    }
    private void FixedUpdate()
    {
        
    }

    #region ��k
    public void ChTime(float speed)
    {
        //���}��k �����N�|�Ǧ^�ɶ��@���t�ק��ܪ��ܼ�
        RB.velocity = Vector3.forward * speed;
    }
    #endregion
}