using UnityEngine;

public class GameOverDetector : MonoBehaviour
{
    [SerializeField] private LayerMask whatToDetect;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(!whatToDetect.Contains(collision.gameObject.layer)) return;
        GameManager.Instance.GameOver();
    }
}
