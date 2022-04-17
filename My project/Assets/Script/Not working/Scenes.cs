using UnityEngine;
/// <summary>
/// 個平台以不同時間旋轉
/// </summary>

public class Scenes : MonoBehaviour
{
    #region 欄位
    [Header("旋轉角度")]
    public float angle = 0;
    [Header("速度")]
    public float time = 2f;
    private float CDtime;
    #endregion
    private void Start()
    {
        CDtime = 0;//時間歸0
    }
    private void FixedUpdate()
    {
        Rotate();//呼叫旋轉
    }
    private void OnTriggerStay(Collider other)
    {
        other.transform.parent = gameObject.transform;
        if (other.tag == "animal")//若是動物在感應區裡
        {
            Animal animal = other.gameObject.GetComponent<Animal>();//呼叫動物的C#
            //animal.ChTime(time);//裡面的方法(ChTime)並將區域時間速度帶入動物移動速度
        }
    }
    #region 方法
    private void Rotate()
    {
        if (CDtime > time)//若計時器時間到了則旋轉角度
        {
            transform.Rotate(0, +angle, 0);
            CDtime = 0;
        }
        CDtime += Time.deltaTime;//沒有就計時器時間+1
    }

    #endregion
}
