using UnityEngine;
/// <summary>
/// 滑鼠旋轉鏡頭
/// </summary>
public class CameraController : MonoBehaviour
{
    #region 欄位
    [Header("場景中央")]
    public Transform stage;
    [Header("儲存位置訊息")]
    public float x;
    public float y = 10;
    [Header("滑鼠靈敏")]
    public float speed = -0.5f;

    [Header("滑鼠滾輪靈敏")]
    public float rollers = 5;
    [Header("與目標距離")]
    public float distance;
    //[Header("距離限制"), Range(1, 20)]
    public float minDis = 5;
    //[Range(1,20)]
    public float maxDis = 10;

    private Quaternion rotationEuler;//旋轉角度(四元數),傳入值轉換為角度(即為Transform的Rotation)
    private Vector3 camerPosition;//攝影機位置

    public Vector2 pos;
    #endregion

    private void Update()
    {
        //Mouse();
        Mobile();
        //text();
    }
    #region 方法
    private void Mouse()
    {
        if (Input.GetMouseButton(0))//長按左鍵
        {
            //transform.LookAt(stage.position);
            //transform.RotateAround(stage.position, transform.right, Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime);
            //transform.RotateAround(stage.position, transform.up, Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime);
            #region 讀取滑鼠X、Y移動數值
            x += Input.GetAxis("Mouse X") * speed * 1000 * Time.deltaTime;
            //print("Mouse X:" + Input.GetAxis("Mouse X"));
            y -= Input.GetAxis("Mouse Y") * speed * 1000 * Time.deltaTime;
            //print("Mouse Y:" + Input.GetAxis("Mouse Y"));
            #endregion
            #region 保證X在360內
            if (x > 360) x -= 360;
            else if (x < 0) x += 360;
            #endregion

        }
        #region 滑鼠滾輪數值
        distance -= Input.GetAxis("Mouse ScrollWheel") * rollers * 100 * Time.deltaTime;
        //print("Mouse ScrollWheel:" + Input.GetAxis("Mouse ScrollWheel"));
        distance = Mathf.Clamp(distance, minDis, maxDis);//距離限制
                                                         //Mathf.Clamp(數值,最小值,最大值)返回最大與最小間的值
        #endregion
        #region 運算攝影機座標&旋轉
        rotationEuler = Quaternion.Euler(y, x, 0);
        camerPosition = rotationEuler * new Vector3(0, 0, -distance) + stage.position;
        //應用
        transform.rotation = rotationEuler;
        transform.position = camerPosition;
        #endregion
    }
    private void Mobile()
    {
        if (Input.touchCount > 0)//觸控螢幕>1
        {
            Touch touch = Input.GetTouch(0);//存取觸碰位置
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);//將觸碰位置定義為世界座標
            print("觸碰:" + touch.position);
            print("世界座標轉換:" + touchPosition);

            if (touch.phase == TouchPhase.Moved)//當觸碰開始移動
            {
                x += touch.position.x * speed * Time.deltaTime;
                //print("Mouse X:" + Input.GetAxis("Mouse X"));
                y -= touch.position.y * speed * Time.deltaTime;
                #region 保證X在360內
                if (touchPosition.x > 360) x -= 360;
                else if (touchPosition.x < 0) x += 360;
                #endregion 
                #region 運算攝影機座標&旋轉
                rotationEuler = Quaternion.Euler(y, x, 0);
                camerPosition = rotationEuler * new Vector3(0, 0, -distance) + stage.position;
                //應用
                transform.rotation = rotationEuler;
                transform.position = camerPosition;
                #endregion
            }
            if (touch.phase == TouchPhase.Stationary)
            {
                x = 0;
                y = 10;
            }
        }

        #region 滑鼠滾輪數值
        distance -= Input.GetAxis("Mouse ScrollWheel") * rollers * 100 * Time.deltaTime;
        //print("Mouse ScrollWheel:" + Input.GetAxis("Mouse ScrollWheel"));
        distance = Mathf.Clamp(distance, minDis, maxDis);//距離限制
                                                         //Mathf.Clamp(數值,最小值,最大值)返回最大與最小間的值
        #endregion
       
    }
    private void text()
    {
        if(Input.touchCount ==1)
        {
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
            if (Input.touches[0].phase==TouchPhase.Moved)
            {
                print("移動" + Input.touches[0].position);
                print("世界移動" + touchPosition);
                x = Input.GetAxis("Mouse X");
                print("水平移動" + x);
            }

        }
    }
    #endregion
}
