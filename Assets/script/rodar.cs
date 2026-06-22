using UnityEngine;

public class RotateImage : MonoBehaviour
{
    public RectTransform imageRect;

    [Header("Rotação")]
    public float speed = 30f;  // graus por segundo

    void Update()
    {
        imageRect.Rotate(0f, 0f, speed * Time.deltaTime);
    }
}