using UnityEngine;

public class FloatImage : MonoBehaviour
{
    public RectTransform imageRect;

    [Header("Movimento")]
    public float amplitude = 50f;  // distância do movimento (pixels)
    public float speed = 1f;       // velocidade

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
