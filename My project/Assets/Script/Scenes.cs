using UnityEngine;
/// <summary>
/// �ӥ��x�H���P�ɶ�����
/// </summary>

public class Scenes : MonoBehaviour
{
    #region ���
    [Header("���ਤ��")]
    public float angle = 60f;
    [Header("�t��")]
    public float time = 2f;
    private float CDtime;
    #endregion
    private void Start()
    {
        CDtime = 0;//�ɶ��k0
    }
    private void Update()
    {
        Rotate();
    }
    #region ��k
    private void Rotate()
    {
        if (CDtime > time)//�Y�p�ɾ��ɶ���F�h���ਤ��
        {
            transform.Rotate(0, +angle, 0);
            CDtime = 0;
        }
        CDtime += Time.deltaTime;//�S���N�p�ɾ��ɶ�+1
    }
    #endregion
}
