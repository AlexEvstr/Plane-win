using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class SnapScrollView : MonoBehaviour, IEndDragHandler
{
    public ScrollRect scrollRect;
    public RectTransform contentPanel;
    private float snapSpeed = 5;
    private float snapThreshold = 0f;

    private List<float> itemPositions;
    private bool isSnapping = false;

    void Start()
    {
        itemPositions = new List<float>();
        for (int i = 0; i < contentPanel.childCount; i++)
        {
            float position = (float)i / (contentPanel.childCount - 1);
            itemPositions.Add(position);
        }
    }

    void Update()
    {
        if (isSnapping)
        {
            float nearestPosition = FindNearestItem();
            float targetX = -nearestPosition * (contentPanel.rect.width - scrollRect.viewport.rect.width);
            float newX = Mathf.Lerp(contentPanel.anchoredPosition.x, targetX, Time.deltaTime * snapSpeed);
            contentPanel.anchoredPosition = new Vector2(newX, contentPanel.anchoredPosition.y);

            if (Mathf.Abs(newX - targetX) < snapThreshold)
            {
                isSnapping = false;
                contentPanel.anchoredPosition = new Vector2(targetX, contentPanel.anchoredPosition.y);
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isSnapping = true;
    }

    private float FindNearestItem()
    {
        float minDistance = float.MaxValue;
        float nearestPosition = 0;

        for (int i = 0; i < itemPositions.Count; i++)
        {
            float targetX = -itemPositions[i] * (contentPanel.rect.width - scrollRect.viewport.rect.width);
            float distance = Mathf.Abs(contentPanel.anchoredPosition.x - targetX);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestPosition = itemPositions[i];
            }
        }

        return nearestPosition;
    }
}
