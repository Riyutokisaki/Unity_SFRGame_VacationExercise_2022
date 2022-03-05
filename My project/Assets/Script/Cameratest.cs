using UnityEngine;

public class Cameratest : MonoBehaviour
{
    #region ���
    [Header("�ؼЪ�")]
    public Transform target;
    [Header("����/�Ӹ`�}��")]
    public bool detail = false;
    [Header("Ĳ�N��m")]
    private Vector3 oneTPosition;
    [Header("�P�ؼжZ��"), Range(0, 50)]
    public float dis = 20f;
    [Header("���ਤ��")]
    private float rotationEnler;
    [Header("�F�ӫ�"), Range(0, 50)]
    public float speed = 15;
    #endregion

    private void Start()
    {
        target = GameObject.Find("�D��").transform;//���D���ø��H�L
        transform.localPosition = Vector3.MoveTowards(transform.position, target.position, -dis);
        // cameraPosition = transform.position;
    }
    private void Update()
    {
        if (detail)//�ۤϪ��p�G�}����T���N��ܥثe���S�g
        {
            MS();
        }
        else//�p�G�Ӹ`�}���OF���N��ܥثe�������Ҧ�
        {
            LS();
        }
        
        //�I�⦸����
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.tapCount == 2) 
            { 
                detail = !detail;
                SwitchPosition();
            }
        }
    }
    #region ��k
    private void LS()//Long Shot
    {
        if (Input.touchCount == 1)//�p�GĲ�N�I>1
        {
            if (Input.touches[0].phase == TouchPhase.Began)
                oneTPosition = Input.touches[0].position;//�x�sĲ�N�I��m
            if (Input.touches[0].phase == TouchPhase.Moved)
            {
                transform.Translate(new Vector3(Input.touches[0].deltaPosition.x * Time.deltaTime * -1, 0, 0));//��v����m����(�u����X)
            }
        }
    }
    private void MS()
    {
        if (Input.touchCount == 1)//�p�GĲ�N�I>1
        {
            if (Input.touches[0].phase == TouchPhase.Began) oneTPosition = Input.touches[0].position;//�x�sĲ�N��m
            if (Input.touches[0].phase == TouchPhase.Moved)//���ʶ}�l
            {
                rotationEnler = Input.touches[0].deltaPosition.x * Time.deltaTime * speed;//���ਤ��
                transform.RotateAround(target.transform.position, Vector3.up, rotationEnler);//�]�w��v������(�ؼ�,�b,����)
            }
        }
    }
    private void SwitchPosition()
    {
        if (detail) transform.localPosition = Vector3.MoveTowards(transform.position, target.position, dis);
        else transform.localPosition = Vector3.MoveTowards(transform.position, target.position, -dis);
    }
    #endregion
}
