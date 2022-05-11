using UnityEngine;
/// <summary>
/// �D��player����
/// </summary>
public class PlayerCharacter : MonoBehaviour
{
    #region ���
    [Header("����")]
    private Rigidbody rb;
    [Header("�ʵe����")]
    private Animator an;
    [Header("�����d��")]
    public Vector3 detectionRange;
    [Range(0,50)]
    public float detectionSize;
    [Header("��m�վ�")]
    public Vector3 startPos;
    [Header("���ʳt��"), Range(0, 50)]
    public float speed;
    #endregion
    private void Start()
    {
        #region ���o��������
        rb = GetComponent<Rigidbody>();
        an = GetComponent<Animator>();
        #endregion
        SetStartPosition();

    }
    private void OnDrawGizmos()
    {
       
            Gizmos.color = new Color(1, 0, 0, .5f);//�P�_�ϳ]�m���Ŧ�
            Gizmos.DrawSphere(transform.position+detectionRange,detectionSize);//�����Ϧ�m
        
    }//��m�������
    private void Update()
    {
        
    }
    #region ��k
    private void SetStartPosition()
    {
        Collider hit = Physics.OverlapSphere(transform.position + detectionRange, detectionSize)[0];
       //print(hit.name);
        transform.position = hit.transform.position+startPos;
    }//�}�l���B���D����m
    public void Move(Transform selection)
    {
        rb.MovePosition(selection.position + startPos);
    }
    #endregion
}
