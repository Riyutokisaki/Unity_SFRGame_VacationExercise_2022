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
    private Transform touchObject;
    //��ܦ�m
    public Vector3 onObject = new Vector3(0, 2.5f, 0);
    private bool skillOpen = false;

    #endregion
 
    private void Update()
    {
        if (skillOpen)
        {
        //��ܦ�m�b�I�������m
            uiUse.transform.position = Camera.main.WorldToScreenPoint(touchObject.position+onObject);

        }
    }
    #region ��k

    public void SkillOn(Transform selection)
    {
        touchObject = selection;
        //��Ҥ�(�ޯ��w��,�bCanvas��m�U).��Bttion
        //BUG �e�����߷|�h�X�{�@��
        uiUse = Instantiate(skill, FindObjectOfType<Canvas>().transform).GetComponent<Image>();
        skillOpen = true;
    } 
    #endregion
}
