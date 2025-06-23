using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryGameManager : MonoBehaviour
{
    public GameObject cardPrefab;
    public Transform cardParent;
    public Sprite[] images;

    private MemoryGame_Card firstCard, secondCard;
    private List<int> cardIds = new List<int>();

    void Start()
    {
        SetupCards();
        StartCoroutine(InitialPreview());
    }

    void SetupCards()
    {
        List<int> ids = new List<int>();
        for (int i = 0; i < images.Length; i++)
        {
            ids.Add(i);
            ids.Add(i); // two of each to make pairs
        }

        Shuffle(ids);

        for (int i = 0; i < ids.Count; i++)
        {
            GameObject obj = Instantiate(cardPrefab, cardParent);
            MemoryGame_Card card = obj.GetComponent<MemoryGame_Card>();
            card.Setup(images[ids[i]], ids[i], this);
            card.FlipFront(); // show all at start
        }
    }

    IEnumerator InitialPreview()
    {
        yield return new WaitForSeconds(2.5f);

        MemoryGame_Card[] allCards = cardParent.GetComponentsInChildren<MemoryGame_Card>();
        foreach (var card in allCards)
        {
            card.FlipBack();
        }
    }

    void Shuffle(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int rnd = Random.Range(i, list.Count);
            int temp = list[rnd];
            list[rnd] = list[i];
            list[i] = temp;
        }
    }

    public void CardRevealed(MemoryGame_Card card)
    {
        if (firstCard == null)
        {
            firstCard = card;
        }
        else if (secondCard == null)
        {
            secondCard = card;
            StartCoroutine(CheckMatch());
        }
    }

    IEnumerator CheckMatch()
    {
        yield return new WaitForSeconds(1f);

        if (firstCard.cardId == secondCard.cardId)
        {
            // Matched - you can add effects here
        }
        else
        {
            firstCard.FlipBack();
            secondCard.FlipBack();
        }

        firstCard = null;
        secondCard = null;
    }
}
