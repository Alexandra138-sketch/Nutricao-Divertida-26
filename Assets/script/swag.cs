using UnityEngine;

public class SwayImage : MonoBehaviour
{
    public RectTransform imageRect;

    [Header("Movimento")]
    public float amplitude = 50f;   // dist�ncia do balanço (pixels)
    public float speed = 1.5f;      // velocidade do balanço

    private Vector2 startPos;

    void Start()
    {
        startPos = imageRect.anchoredPosition;
    }

    void Update()
    {
        float x = Mathf.Sin(Time.time * speed) * amplitude;
        imageRect.anchoredPosition = new Vector2(startPos.x + x, startPos.y);
    }
}