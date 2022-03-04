using UnityEngine;

public class Cameratest : MonoBehaviour
{
    #region 欄位
    [Header("目標物")]
    public Transform target;
    [Header("全景/細節開關")]
    private bool detail = false;
    [Header("攝影機位置")]
    private Vector3 cameraPosition;
    [Header("與目標距離")]
    public float maxDis;
    public float minDis;
    [Header("旋轉角度")]
    private Quaternion rotationEnler;
    #endregion

    private void Start()
    {
        target = GameObject.Find("主角").transform;//找到主角並跟隨他
        cameraPosition = transform.position;
    }
    private void Update()
    {
        if (!detail)//如果細節開關是F那就表示目前為全景模式
        {
            Panorama();
        }
    }
    #region 方法
    private void Panorama()
    {
        if (Input.touchCount == 1)//如果觸摸點>1
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                Vector3 tPosition = Input.touches[0].position;//儲存觸摸點位置
            }
            if (Input.touches[0].phase == TouchPhase.Moved)
            {
                transform.Translate(new Vector3(Input.touches[0].deltaPosition.x * Time.deltaTime * -1, cameraPosition.y , 0));
                

            }
            
        }
        

    }

    #endregion
}
