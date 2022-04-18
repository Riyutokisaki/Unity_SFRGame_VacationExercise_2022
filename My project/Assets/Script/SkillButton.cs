using UnityEngine.UI;
using UnityEngine;
/// <summary>
/// 技能按鈕
/// 20220418 變換速度(改為增加減少)
/// </summary>

public class SkillButton : MonoBehaviour
{
    #region 欄位
    [Header("動物")]
    private Animal animal;//使用技能項目
    [Header("速度值"), Range(-20, 20)]
    public float speed;
    //UI控制器的開關
    private UIManager skillOpen;
    //觸碰項目
    public Transform Target;
  
    #endregion
    private void Awake()
    {
        //喚醒時取得UI控制器與選擇物件
        skillOpen = GameObject.Find("UI").GetComponent<UIManager>();
        Target = skillOpen.touchObject;
       
    }
    
    public void SkillFast()
    {
        animal = Target.GetComponent<Animal>();//獲得障礙物腳本
        animal.SkillUse(speed);//呼叫動物改變速度的方法
        print("使用技能" + speed);
        skillOpen.skillOpen = false;//關閉UI控制中顯示開關
        Destroy(GameObject.Find("skill UI(Clone)"));//刪除SkillUI
    }
}
