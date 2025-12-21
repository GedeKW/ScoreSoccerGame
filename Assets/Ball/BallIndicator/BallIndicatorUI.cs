using UnityEngine;

public class BallIndicatorUI : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;

    void Awake()
    {
        canvasGroup.alpha = 0;
    }
    
    public void SetPosition(Transform targetTrasform)
    {
        transform.position = new Vector2(targetTrasform.position.x,transform.position.y);
    }

    public void ToggleVisibility(bool visible)
    {
        canvasGroup.alpha = visible? 1 : 0;
    }
    
}
