using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class ShopUI : MonoBehaviour
{
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }
    public void Open()
    {
        ChangeCanvasGroupState(1f, true);
    }

    public void Close()
    {
        ChangeCanvasGroupState(0f, false);
    }

    private void ChangeCanvasGroupState(float alpha, bool blocksRaycast)
    {
        _canvasGroup.alpha = alpha;
        _canvasGroup.blocksRaycasts = blocksRaycast;
    }
}
