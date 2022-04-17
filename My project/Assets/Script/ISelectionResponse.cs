using UnityEngine;
/// <summary>
/// 觸控變換材質插槽
/// 20220415尚未完善
/// </summary>

internal interface ISelectionResponse
{
    void OnSelect(Transform selection);
    void OnDeselect(Transform selection);
}