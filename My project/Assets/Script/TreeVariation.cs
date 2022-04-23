using UnityEngine;

/// <summary>
/// �ޯ�ϥγ�V����20220423
/// </summary>

public class TreeVariation : MonoBehaviour
{
    #region ���
    [Header("�t��")]
    public float speed=1;
    public float objectiveSpeed=2;
    [Header("��ҫ�")]
    public GameObject original;
    [Header("�\��ҫ�")]
    public GameObject[] wilting;
    public bool convert = false;//���ܤ�
    public int coldTime = 10;//�]�w�N�o�ɶ�

    public int cold;//��ڧN�o�ɶ�
    [Header("�ɤl�ĪG")]
    public ParticleSystem psSolving;
    #endregion

    private void FixedUpdate()
    {
        TreeChange();
    }
    #region
    private void TreeChange()
    {
        if (speed == objectiveSpeed&&!convert&&cold==0)//��t�׵���]�w�ؼХB�}��������
        {
            convert = true;//�}�ҧ���
            var completion = GameObject.Find("judgment").GetComponent<TaskList>();//�����Ȥ���
            completion.b_completion = true;//�V���Ȥ��ߦ^�ǥ��ȧ���
            original.SetActive (false);//������l�ҫ�
            Instantiate(wilting[0], transform);//��ҤƼҫ�0�b��m
            cold = 0;//�p���k�s
            speed = 0;//�t���٭�H���h��Ĳ�o
            
        }

        if (cold == coldTime && convert)
        {
            Destroy(GameObject.Find("tree06"));//�����\��ҫ�
            Instantiate(wilting[1], transform);//�s�y�̲׼ҫ�1�b���I
            psSolving.Play();//�������
            convert = false;//��������

        }
        if (cold != coldTime&& convert) cold++;
    }

    //�ޯ�ϥ�
    public void SkillUse(float get)
    {
        speed += get;
        //�̷�SkillButton�ǨӪ��t�׭ק�20220423
    }
    #endregion
}
