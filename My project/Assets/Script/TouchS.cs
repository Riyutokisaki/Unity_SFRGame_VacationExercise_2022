using UnityEngine;
/// <summary>
/// Ĳ�I�P�w�t��
/// 20220415 �i�B�@�B���٨S���� �Ա�https://www.youtube.com/watch?v=QDldZWvNK_E
/// ��ܩ������ �f�tC#��:hightlightSelectionResponse�BISelectionResponse
/// 20220416���XUI �f�tC#��UIManager 
/// </summary>

public class TouchS : MonoBehaviour
{
    #region ���
    [Header("��Ĳ�I����TAG")]
    public string draggingTag;
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
    #endregion
    private void Start()
    {
        skillUI = GameObject.Find("UI").GetComponent<UIManager>();//���qUI������o�}��
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
        #region Ĳ�I
        RayTouch();
        #endregion
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
    private void RayTouch()
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
                //�p�GRAY�I�쪺����TAG�����W��
                if (Physics.Raycast(ray, out hit) && hit.collider.tag == draggingTag)
                {
                    //���o�I���m������
                    var selection = hit.transform;
                    //�o�쨺�Ӫ��󪺧����m
                    //var selectionRenderer = selection.GetComponent<Renderer>();
                    //print("Ĳ�I�쪫��");
                    //orimaterial = selectionRenderer.material;

                    //���褣����0���ܡA�������������w����
                    //if (selectionRenderer != null)selectionRenderer.material = hightmaterial;

                    //�I�sUI����
                    skillUI.SkillOn(selection);
                    _salaction = selection;
                }
            }

        }
    }
}

