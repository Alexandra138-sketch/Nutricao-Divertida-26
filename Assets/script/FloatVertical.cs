using UnityEngine;

public class FloatVertical : MonoBehaviour
{
    public RectTransform imageRect;

    [Header("Movimento")]
    public float amplitude = 50f;
    public float speed = 1f;

    private Vector2 startPos;

    void Start()
    {
        startPos = imageRect.anchoredPosition;
    }

    void Update()
    {
        float y = Mathf.Sin(Time.time * speed) * amplitude;
        imageRect.anchoredPosition = new Vector2(startPos.x, startPos.y + y);
    }
}