using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MemoryGame_Card : MonoBehaviour, IPointerClickHandler
{
    public GameObject front;         // Parent GameObject showing image
    public GameObject back;          // Parent GameObject for back design
    public Image frontImage;         // The Image component to show sprite

    [HideInInspector]
    public int cardId;

    private MemoryGameManager gameManager;
    private bool isFlipped = false;
    private bool isMatched = false;

    public void Setup(Sprite image, int id, MemoryGameManager manager)
    {
        cardId = id;
        frontImage.sprite = image;
        gameManager = manager;

        FlipBack();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isFlipped || isMatched) return;

        FlipFront();
        gameManager.CardRevealed(this);
        isFlipped = true;
    }

    public void FlipBack()
    {
        front.SetActive(false);
        back.SetActive(true);
        isFlipped = false;
    }

    public void FlipFront()
    {
        front.SetActive(true);
        back.SetActive(false);
        isFlipped = true;
    }
}
