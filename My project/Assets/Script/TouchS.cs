using UnityEngine;
/// <summary>
/// 觸碰判定系統
/// 20220415 可運作、但還沒完善 詳情https://www.youtube.com/watch?v=QDldZWvNK_E
/// 選擇明顯顯示 搭配C#為:hightlightSelectionResponse、ISelectionResponse
/// 20220416跳出UI 搭配C#為UIManager 
/// </summary>

public class TouchS : MonoBehaviour
{
    #region 欄位
    [Header("能觸碰物件TAG")]
    public string draggingTag;
    [Header("攝影機")]
    public Camera cam;
    [Header("選擇_材質替換")]
    public Material hightmaterial;
    [Header("原有材質")]
    public Material orimaterial;
    private hightlightSelectionResponse _selectionResponse;
    public Transform _salaction;
    //UI召喚
    private UIManager skillUI;
    #endregion
    private void Start()
    {
        skillUI = GameObject.Find("UI").GetComponent<UIManager>();//先從UI控制中取得腳本
    }
    void FixedUpdate()
    {
        #region 材質還原
        if (_salaction != null)
        {
            var selectionRenderer = _salaction.GetComponent<Renderer>();
            if (selectionRenderer !=null)
            {
                selectionRenderer.material = orimaterial;
            }

        }
        #endregion
        #region 觸碰
        RayTouch();
        #endregion
        #region 觸碰物材質轉換
        if (_salaction != null)
        {
            var selectionRenderer = _salaction.GetComponent<Renderer>();
            if (selectionRenderer != null)
            {
                selectionRenderer.material = hightmaterial;
            }

        }
        #endregion
    }
    private void RayTouch()
    {
        //若是觸控點=1
        if (Input.touchCount == 1)
        {
            //紀錄觸控訊息
            Touch touch = Input.touches[0];
            Vector3 pos = touch.position;
            //若是觸碰開始
            if (touch.phase == TouchPhase.Began)
            {
                //觸碰位置攝影機發出RAY
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(pos);
                _salaction = null;
                //如果RAY碰到的物件TAG為欄位名稱
                if (Physics.Raycast(ray, out hit) && hit.collider.tag == draggingTag)
                {
                    //取得碰到位置的物件
                    var selection = hit.transform;
                    //得到那個物件的材質位置
                    //var selectionRenderer = selection.GetComponent<Renderer>();
                    //print("觸碰到物件");
                    //orimaterial = selectionRenderer.material;

                    //材質不等於0的話，把材質替換為指定材質
                    //if (selectionRenderer != null)selectionRenderer.material = hightmaterial;

                    //呼叫UI控制
                    skillUI.SkillOn(selection);
                    _salaction = selection;
                }
            }

        }
    }
}

