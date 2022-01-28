using UnityEngine;
/// <summary>
/// �������Y
/// </summary>
public class Camera : MonoBehaviour
{
    #region ��k
    [Header("��������")]
    public Transform stage;
    [Header("�x�s��m�T��")]
    public float x;
    public float y = 10;
    [Header("�ƹ��F��")]
    public float speed = 1;
    
    [Header("�ƹ��u���F��")]
    public float rollers = 5;
    [Header("�P�ؼжZ��")]
    public float distance;
    //[Header("�Z������"), Range(1, 20)]
    public float minDis = 5;
    //[Range(1,20)]
    public float maxDis = 10;

    private Quaternion rotationEuler;//���ਤ��(�|����),�ǤJ���ഫ������(�Y��Transform��Rotation)
    private Vector3 camerPosition;//��v����m
    #endregion
   
    private void Update()
    {
        if (Input.GetMouseButton(0))//��������
        {
            //transform.LookAt(stage.position);
            //transform.RotateAround(stage.position, transform.right, Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime);
            //transform.RotateAround(stage.position, transform.up, Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime);
            #region Ū���ƹ�X�BY���ʼƭ�
            x += Input.GetAxis("Mouse X") * speed *1000 * Time.deltaTime;
            //print("Mouse X:" + Input.GetAxis("Mouse X"));
            y -= Input.GetAxis("Mouse Y") * speed *1000 * Time.deltaTime;
            //print("Mouse Y:" + Input.GetAxis("Mouse Y"));
            #endregion
            #region �O��X�b360��
            if (x > 360) x -= 360;
            else if (x < 0) x += 360;
            #endregion
            
        }
        #region �ƹ��u���ƭ�
        distance -= Input.GetAxis("Mouse ScrollWheel") * rollers *100 * Time.deltaTime;
        //print("Mouse ScrollWheel:" + Input.GetAxis("Mouse ScrollWheel"));
        distance = Mathf.Clamp(distance, minDis, maxDis);//�Z������
                                                         //Mathf.Clamp(�ƭ�,�̤p��,�̤j��)��^�̤j�P�̤p������
        #endregion
        #region �B����v���y��&����
        rotationEuler = Quaternion.Euler(y, x, 0);
        camerPosition = rotationEuler * new Vector3(0, 0, -distance) + stage.position;
        //����
        transform.rotation = rotationEuler;
        transform.position = camerPosition;
        #endregion
    }
}
