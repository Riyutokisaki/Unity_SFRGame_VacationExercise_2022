using UnityEngine;
using System;////Array.IndexOf�ϥ�
/// <summary>
/// Ĳ�I�P�w�t��
/// 20220415 �i�B�@�B���٨S���� �Ա�https://www.youtube.com/watch?v=QDldZWvNK_E
/// ��ܩ������ �f�tC#��:hightlightSelectionResponse�BISelectionResponse
/// 20220416���XUI �f�tC#��UIManager 
/// 20220429�a�����
/// </summary>

public class TouchS : MonoBehaviour
{
    #region ���
    [Header("��Ĳ�I����TAG")]
    public string[] draggingTag;
    [Header("��v��")]
    public Camera cam;
    [Header("���_�������")]
    public Material hightmaterial;
    [Header("�즳����")]
    public Material orimaterial;
    private hightlightSelectionResponse _selectionResponse;
    public Transform _salaction;
    //UI�l��
    private UIManager skillUI;
    private GroundJudgment ground;
    #endregion
    private void Start()
    {
        skillUI = GameObject.Find("System").GetComponent<UIManager>();//���qUI������o�}��
        ground= GameObject.Find("System").GetComponent<GroundJudgment>();
    }

    void FixedUpdate()
    {
        #region �����٭�
        if (_salaction != null)
        {
            var selectionRenderer = _salaction.GetComponent<Renderer>();
            if (selectionRenderer !=null)
            {
                selectionRenderer.material = orimaterial;
            }

        }
        #endregion
        
        RayTouch();//Ĳ�I
        
        #region Ĳ�I�������ഫ
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
    private void RayTouch()//Ĳ�I
    {
        //�Y�OĲ���I=1
        if (Input.touchCount == 1)
        {
            //����Ĳ���T��
            Touch touch = Input.touches[0];
            Vector3 pos = touch.position;
            //�Y�OĲ�I�}�l
            if (touch.phase == TouchPhase.Began)
            {
                //Ĳ�I��m��v���o�XRAY
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(pos);
                _salaction = null;
                //if (Physics.Raycast(ray, out hit)) print(Array.IndexOf(draggingTag, hit.collider.tag));//����Ĳ�I��20220423
                if (Physics.Raycast(ray, out hit) && Array.IndexOf(draggingTag, hit.collider.tag)>-1)//Array.IndexOf(�}�C,�n�䪺��) �p�G���N�^��1�A�S���N�^��-1(20220423)�A�p�GRAY�I�쪺����TAG�����W��||���W�ٲŦX���e
                {
                    //���o�I���m������
                    var selection = hit.transform;
                    //�o�쨺�Ӫ��󪺧����m
                    orimaterial = selection.GetComponent<Renderer>().material;
                    //print("Ĳ�I�쪫��");
                    //orimaterial = selectionRenderer.material;

                    //���褣����0���ܡA�������������w����
                    //if (selectionRenderer != null)selectionRenderer.material = hightmaterial;

                    //�I�sUI����
                    skillUI.SkillOn(selection);
                    _salaction = selection;
                }
                #region �a�O
                if (Physics.Raycast(ray, out hit) && hit.collider.tag == "area"&& !skillUI.skillOpen)//�ޯ�UI���O�}���~�ഫ�a�O
                {
                    var selection = hit.transform;
                    print(selection.name);
                    orimaterial = selection.GetComponent<Renderer>().material;
                    ground.OnGround(selection);
                    _salaction = selection;

                }
                #endregion
            }
            if (touch.phase == TouchPhase.Ended)//����Ĳ�I�N�a�O��_
            {
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(pos);
                if (Physics.Raycast(ray, out hit) && hit.collider.tag == "area")
                {
                    var selectionRenderer = _salaction.GetComponent<Renderer>().material;
                    if (selectionRenderer != null)
                    {
                        selectionRenderer = orimaterial;
                    }

                }
                //_salaction = null;
            }    
        }
    }
}

