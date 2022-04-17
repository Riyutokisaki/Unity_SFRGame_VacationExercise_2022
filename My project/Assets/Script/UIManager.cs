using UnityEngine.UI;
using UnityEngine;
/// <summary>
/// 20220416 UI顯示 獨立 
/// </summary>

public class UIManager : MonoBehaviour
{
    #region 欄位
    [Header("技能氣泡框")]
    public Image skill;
    //實例化欄位
    private Image uiUse;
    private Transform touchObject;
    //顯示位置
    public Vector3 onObject = new Vector3(0, 2.5f, 0);
    private bool skillOpen = false;

    #endregion
 
    private void Update()
    {
        if (skillOpen)
        {
        //顯示位置在點擊物件位置
            uiUse.transform.position = Camera.main.WorldToScreenPoint(touchObject.position+onObject);

        }
    }
    #region 方法

    public void SkillOn(Transform selection)
    {
        touchObject = selection;
        //實例化(技能氣泡框,在Canvas位置下).的Bttion
        //BUG 畫面中心會多出現一個
        uiUse = Instantiate(skill, FindObjectOfType<Canvas>().transform).GetComponent<Image>();
        skillOpen = true;
    } 
    #endregion
}
