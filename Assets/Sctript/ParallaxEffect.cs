using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public float multiplier = 0.05f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 center = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Vector2 offset = (mousePos - center) * multiplier;

        Vector3 targetPos = startPos + new Vector3(offset.x, offset.y, 0);
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos, Time.deltaTime * 5f);
    }
}