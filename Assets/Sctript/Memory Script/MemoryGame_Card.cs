using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class MemoryGame_Card : MonoBehaviour, IPointerClickHandler
{
    public GameObject front;
    public GameObject back;
    public Image frontImage;

    [HideInInspector] public int cardId;

    private MemoryGameManager gameManager;
    private bool isFlipped = false;
    private bool isMatched = false;
    private bool isAnimating = false;

    public void Setup(Sprite image, int id, MemoryGameManager manager)
    {
        cardId = id;
        frontImage.sprite = image;
        gameManager = manager;

        // Ensure card starts hidden
        front.SetActive(false);
        back.SetActive(true);
        transform.localRotation = Quaternion.identity;
        isFlipped = false;
        isAnimating = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isFlipped || isMatched || isAnimating) return;

        StartCoroutine(FlipToFront());
        gameManager.CardRevealed(this);
    }

    public IEnumerator FlipToFront()
    {
        isAnimating = true;
        yield return StartCoroutine(Flip(0f, 90f));
        back.SetActive(false);
        front.SetActive(true);
        yield return StartCoroutine(Flip(90f, 180f));
        transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        isFlipped = true;
        isAnimating = false;
    }

    public void FlipBack()
    {
        if (!gameObject.activeInHierarchy) return;
        StartCoroutine(FlipToBack());
    }

    private IEnumerator FlipToBack()
    {
        isAnimating = true;
        yield return StartCoroutine(Flip(180f, 90f));
        front.SetActive(false);
        back.SetActive(true);
        yield return StartCoroutine(Flip(90f, 0f));
        transform.localRotation = Quaternion.identity;
        isFlipped = false;
        isAnimating = false;
    }

    private IEnumerator Flip(float from, float to)
    {
        float duration = 0.25f;
        float time = 0f;

        while (time < duration)
        {
            float angle = Mathf.Lerp(from, to, time / duration);
            transform.localRotation = Quaternion.Euler(0f, angle, 0f);
            time += Time.deltaTime;
            yield return null;
        }

        transform.localRotation = Quaternion.Euler(0f, to, 0f);
    }

    public void MarkAsMatched()
    {
        isMatched = true;
    }

}
