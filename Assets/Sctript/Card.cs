using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int cardId;
    public Image frontImage;
    public Sprite frontSprite;
    public GameManager gameManager;

    private bool isFlipped = false;

    public void Setup(Sprite image, int id, GameManager manager)
    {
        frontSprite = image;
        cardId = id;
        gameManager = manager;
        frontImage.sprite = frontSprite;
        frontImage.enabled = false;
    }

    public void OnClick()
    {
        if (isFlipped) return;

        Flip();
        gameManager.CardRevealed(this);
    }

    public void Flip()
    {
        isFlipped = true;
        frontImage.enabled = true;
        GetComponent<Image>().enabled = false;
    }

    public void FlipBack()
    {
        isFlipped = false;
        frontImage.enabled = false;
        GetComponent<Image>().enabled = true;
    }
}