using UnityEngine.UI;
using UnityEngine;
/// <summary>
/// 20220416 UI��� �W��
/// </summary>

public class UIManager : MonoBehaviour
{
    #region ���
    [Header("�ޯ��w��")]
    public Image skill;
    //��Ҥ����
    private Image uiUse;
    public Transform touchObject;
    [Header("��ܦ�m")]
    public Vector3 onObject = new Vector3(0, 2.5f, 0);
    //�ޯ�UI�O�_���}
    public bool skillOpen = false;

    public int coldTime = 100;//�]�w�N�o�ɶ�
    private int cold;//��ڧN�o�ɶ�

    #endregion

    private void FixedUpdate()
    {
        //��ܮ�w��
        if (skillOpen)
        {
        //��ܦ�m�b�I�������m
            uiUse.transform.position = Camera.main.WorldToScreenPoint(touchObject.position+onObject);
            //��N�o�ɶ��� �R�����ϥΪ�SKILLUI
            if (cold == coldTime)
            {
                Destroy(GameObject.Find("skill UI(Clone)"));
                print("�R��UI");
                
            }
            else cold++;

        }
       
    }
    #region ��k

    public void SkillOn(Transform selection)
    {
        skillOpen = true;//SKILLOPEN���}
        touchObject = selection;//��ܪ���
        //��Ҥ�(�ޯ��w��,�bCanvas��m�U).��Bttion
        //BUG �e�����߷|�h�X�{�@��
        uiUse = Instantiate(skill, FindObjectOfType<Canvas>().transform).GetComponent<Image>();//��Ҥ�
        cold = 0;//�p�ɥΨӲM��
    }
    
    #endregion
}
