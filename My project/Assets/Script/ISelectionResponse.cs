using UnityEngine;
/// <summary>
/// Ĳ���ܴ����贡��
/// 20220415�|������
/// </summary>

internal interface ISelectionResponse
{
    void OnSelect(Transform selection);
    void OnDeselect(Transform selection);
}