using UnityEngine;
using UnityEngine.UI;

public class MemoryGame_Card : MonoBehaviour
{
    public GameObject front;  // image side
    public GameObject back;   // back side

    private bool isFlipped = false;

    public void ShowFront()
    {
        front.SetActive(true);
        back.SetActive(false);
        isFlipped = true;
    }

    public void ShowBack()
    {
        front.SetActive(false);
        back.SetActive(true);
        isFlipped = false;
    }

    public void Flip()
    {
        if (isFlipped) ShowBack();
        else ShowFront();
    }
}
