using UnityEngine.UI;
using UnityEngine;
/// <summary>
/// �ޯ���s
/// 20220418 �ܴ��t��(�אּ�W�[���)
/// </summary>

public class SkillButton : MonoBehaviour
{
    #region ���
    [Header("�ʪ�")]
    private Animal animal;//�ϥΧޯඵ��
    [Header("�t�׭�"), Range(-20, 20)]
    public float speed;
    //UI������}��
    private UIManager skillOpen;
    //Ĳ�I����
    public Transform Target;
  
    #endregion
    private void Awake()
    {
        //����ɨ��oUI����P��ܪ���
        skillOpen = GameObject.Find("UI").GetComponent<UIManager>();
        Target = skillOpen.touchObject;
       
    }
    
    public void SkillFast()
    {
        animal = Target.GetComponent<Animal>();//��o��ê���}��
        animal.SkillUse(speed);//�I�s�ʪ����ܳt�ת���k
        print("�ϥΧޯ�" + speed);
        skillOpen.skillOpen = false;//����UI�����ܶ}��
        Destroy(GameObject.Find("skill UI(Clone)"));//�R��SkillUI
    }
}
