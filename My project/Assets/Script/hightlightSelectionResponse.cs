using UnityEngine;
/// <summary>
/// Ĳ���ܴ�����
/// 20220415�|������
/// </summary>
internal class hightlightSelectionResponse : MonoBehaviour
{
    [Header("���_�������")]
    public Material hightmaterial;
    [Header("�즳����")]
    public Material orimaterial;
    public void OnSelect(Transform selection)
    {
        var selectionRenderer = selection.GetComponent<Renderer>();
        if (selectionRenderer != null)
        {
            selectionRenderer.material = hightmaterial;
        }

    }
    public void OnDeselect(Transform selection)
    {
        var selectionRenderer = selection.GetComponent<Renderer>();
        if (selectionRenderer != null)
        {
            selectionRenderer.material = orimaterial;
        }
    }
}