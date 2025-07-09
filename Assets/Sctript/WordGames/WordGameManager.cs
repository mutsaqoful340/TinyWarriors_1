using UnityEngine;
using TMPro;

public class WordGameManager : MonoBehaviour
{
    [Header("Game Settings")]
    public string correctWord = "CULT";
    public DropSlot[] slots;
    public TMP_Text feedbackText;
    public GameObject collectionPanel;

    public void CheckIfAllSlotsFilled()
    {
        string playerWord = "";
        foreach (var slot in slots)
        {
            if (string.IsNullOrEmpty(slot.slotText.text))
                return;

            playerWord += slot.slotText.text;
        }

        if (playerWord == correctWord)
        {
            feedbackText.text = "Benar!";
            feedbackText.color = Color.green;
        }
        else
        {
            feedbackText.text = "Salah!";
            feedbackText.color = Color.red;
        }
    }

    public void CheckWin()
    {
        bool allCorrect = true;

        foreach (DropSlot slot in slots)
        {
            if (slot.slotText.text != slot.GetCorrectLetter())
            {
                allCorrect = false;
                break;
            }
        }

        if (allCorrect)
        {
            feedbackText.text = "";
            feedbackText.color = Color.green;
            Debug.Log("🎉 Semua huruf benar!");
            collectionPanel.SetActive(true); // Tampilkan panel koleksi jika semua benar
        }
        else
        {
            feedbackText.text = "";
            Debug.Log("Masih ada huruf yang salah.");
        }
    }

    public void ResetBoard()
    {
        foreach (var slot in slots)
        {
            slot.slotText.text = "";
        }

        feedbackText.text = "";

        foreach (var letter in GameObject.FindGameObjectsWithTag("Letter"))
        {
            letter.SetActive(true);
            DragLetter dragLetter = letter.GetComponent<DragLetter>();
            if (dragLetter != null)
            {
                dragLetter.ResetPosition();
            }
        }
    }
}
