using UnityEngine;

public class ScoreDetector : MonoBehaviour
{
    [SerializeField] private LayerMask whatToDetect;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(!whatToDetect.Contains(collision.gameObject.layer)) return;
        ScoreManager.Instance.AddScore(1);
        Debug.Log("Score");
    }


    // protected bool CorrectLayer(Collider2D collider)
    // {
    //     int colLayer = 1 << collider.gameObject.layer;
        

    //     return (whatToPull.value & colLayer) != 0;
    // }
}


