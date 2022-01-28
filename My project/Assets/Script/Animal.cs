using UnityEngine;

public class Animal : MonoBehaviour
{
    #region 欄位
    //[Header("移動速度")]
    [Header("剛體")]
    public Rigidbody RB;

    #endregion
    private void Start()
    {
        RB = GetComponent<Rigidbody>();//取得剛體
    }
    private void FixedUpdate()
    {
        
    }

    #region 方法
    public void ChTime(float speed)
    {
        //公開方法 場景將會傳回時間作為速度改變的變數
        RB.velocity = Vector3.forward * speed;
    }
    #endregion
}