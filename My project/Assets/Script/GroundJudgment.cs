using UnityEngine;
/// <summary>
/// �a�����~�P�w20220429
/// </summary>


public class GroundJudgment : MonoBehaviour
{

    #region ���
    public Transform touchObject;
    [Header("�D��")]
    public Transform rem;
    #endregion
    public void OnGround(Transform selection)
    {
        touchObject = selection;
        PlayerCharacter player = GameObject.Find("�D��").GetComponent<PlayerCharacter>();
        if (touchObject.GetComponent<area>().haveObstacle)
        {
            print("�L�k�q�L");
        }
        else
        {
            player.Move(selection);//�I�s�D������
        }
    }
}
