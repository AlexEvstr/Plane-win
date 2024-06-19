using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    private float scrollSpeed = 1.0f;
    private Vector2 initialPosition;
    private float backgroundHeight;

    private void Awake()
    {
        initialPosition = transform.position;
        backgroundHeight = GetComponent<BoxCollider2D>().size.y / 2;
    }

    private void Update()
    {
        ScrollBackground();
    }

    private void ScrollBackground()
    {
        transform.Translate(Vector2.down * scrollSpeed * Time.deltaTime);
        if (transform.position.y < (initialPosition.y - backgroundHeight))
        {
            ResetBackgroundPosition();
        }
    }

    private void ResetBackgroundPosition()
    {
        transform.position = initialPosition;
    }
}