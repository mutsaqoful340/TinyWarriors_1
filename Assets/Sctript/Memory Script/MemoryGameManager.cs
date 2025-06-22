using System.Collections;
using UnityEngine;

public class MemoryGameManager : MonoBehaviour
{
    public MemoryGame_Card[] cards;

    private void Start()
    {
        StartCoroutine(StartSequence());
    }

    IEnumerator StartSequence()
    {
        // Show all cards' front
        foreach (MemoryGame_Card card in cards)
            card.ShowFront();

        // Wait for 3 seconds
        yield return new WaitForSeconds(3f);

        // Hide all cards
        foreach (MemoryGame_Card card in cards)
            card.ShowBack();

        // Now you can enable input handling, etc.
    }
}
