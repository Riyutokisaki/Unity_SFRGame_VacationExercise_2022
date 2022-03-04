using UnityEngine;

public class Cameratest : MonoBehaviour
{
    #region ���
    [Header("�ؼЪ�")]
    public Transform target;
    [Header("����/�Ӹ`�}��")]
    private bool detail = false;
    [Header("��v����m")]
    private Vector3 cameraPosition;
    [Header("�P�ؼжZ��")]
    public float maxDis;
    public float minDis;
    [Header("���ਤ��")]
    private Quaternion rotationEnler;
    #endregion

    private void Start()
    {
        target = GameObject.Find("�D��").transform;//���D���ø��H�L
        cameraPosition = transform.position;
    }
    private void Update()
    {
        if (!detail)//�p�G�Ӹ`�}���OF���N��ܥثe�������Ҧ�
        {
            Panorama();
        }
    }
    #region ��k
    private void Panorama()
    {
        if (Input.touchCount == 1)//�p�GĲ�N�I>1
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                Vector3 tPosition = Input.touches[0].position;//�x�sĲ�N�I��m
            }
            if (Input.touches[0].phase == TouchPhase.Moved)
            {
                transform.Translate(new Vector3(Input.touches[0].deltaPosition.x * Time.deltaTime * -1, cameraPosition.y , 0));
                

            }
            
        }
        

    }

    #endregion
}
