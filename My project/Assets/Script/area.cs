using UnityEngine;
/// <summary>
/// 區域內是否有生物20220501
/// </summary>
public class area : MonoBehaviour
{
    #region 欄位
    public bool haveObstacle;
    [Header("偵測範圍")]
    public Vector3 detectionRange=Vector3.one;
    public Vector3 detectionHight;

    #endregion
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0, 1,.5f);//判斷區設置為藍色
        Gizmos.DrawCube(transform.position+detectionHight, detectionRange);//偵測區位置
    }

    private void Update()
    {
        CheckArea();
    }
    #region 方法
    private void CheckArea()//檢測內部是否有東西
    {
        haveObstacle = false;//每幀檢測前先關閉

        Collider[] hit = Physics.OverlapBox(transform.position + detectionHight, detectionRange/2, Quaternion.Euler(0, 0, 0),6);//(中心點，大小，旋轉，圖層碼)
        int? hitHave = hit?.Length;
        if(hitHave!=null)//若內部有東西
        {
            //print(hit[0].name + "碰到" + transform.name);
            haveObstacle = true;//有障礙物開啟
            hit = null;//刪除內部物品

        }
    }
    #endregion
}
