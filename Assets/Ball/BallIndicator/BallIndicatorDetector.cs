using UnityEngine;

public class BallIndicatorDetector : MonoBehaviour
{
    [SerializeField] private LayerMask whatToDetect;
    [SerializeField] private BallIndicatorUI indicatorUI;

    private Transform _ballTransfom;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(!whatToDetect.Contains(collision.gameObject.layer)) return;
        _ballTransfom = collision.transform;
        indicatorUI.ToggleVisibility(true);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(!whatToDetect.Contains(collision.gameObject.layer)) return;
        _ballTransfom = null;
        indicatorUI.ToggleVisibility(false);
    }

    void Update()
    {
        if(_ballTransfom != null)
        {
            indicatorUI.SetPosition(_ballTransfom);
        }
    }

}
