using UnityEngine;
using UnityEngine.EventSystems;

public class DragLetter : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("Letter Settings")]
    public string letter;

    private Vector3 startPosition;
    private Transform startParent;
    private bool droppedOnSlot = false;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = transform.localPosition;
        startParent = transform.parent;
        droppedOnSlot = false;

        transform.SetParent(transform.root, true);

        // Supaya raycast tembus ke slot
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Aktifkan lagi raycast setelah drag selesai
        canvasGroup.blocksRaycasts = true;

        if (!droppedOnSlot)
        {
            ResetPosition();
        }
    }

    public void ResetPosition()
    {
        transform.SetParent(startParent);
        transform.localPosition = startPosition;
    }

    public void SetToSlot(Transform slot)
    {
        droppedOnSlot = true;
        transform.SetParent(slot, false);  // false = local pos, rot, scale otomatis relatif ke slot
        RectTransform rt = GetComponent<RectTransform>();
        rt.anchoredPosition = Vector2.zero;
        rt.localRotation = Quaternion.identity;
        rt.localScale = Vector3.one;
    }


}
