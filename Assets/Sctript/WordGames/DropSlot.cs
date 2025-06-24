using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class DropSlot : MonoBehaviour, IDropHandler
{
    [Header("Slot Settings")]
    [SerializeField] private string correctLetter;
    [SerializeField] private WordGameManager gameManager;
    public TMP_Text slotText;

    public void OnDrop(PointerEventData eventData)
    {
        DragLetter draggedLetter = eventData.pointerDrag.GetComponent<DragLetter>();

        if (draggedLetter != null)
        {
            // Cek apakah huruf ini cocok sama slotnya
            if (draggedLetter.letter == correctLetter)
            {
                // Masukkan huruf ke slot
                draggedLetter.SetToSlot(transform);

                if (slotText != null)
                    slotText.text = draggedLetter.letter;

                gameManager.CheckWin();
            }
            else
            {
                // Salah slot, balikin posisi huruf
                draggedLetter.ResetPosition();
            }
        }
    }




    public string GetCorrectLetter() => correctLetter;
}
