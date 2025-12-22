using UnityEngine;

public class AddTimerDetector : MonoBehaviour
{
    [SerializeField] private LayerMask whatToDetect;
    public bool hasDetected = false;

    [SerializeField] private AudioSource audioSource;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(!whatToDetect.Contains(collision.gameObject.layer) || hasDetected) return;
        hasDetected = true;
        TimerManager.Instance.AddTimer();
        //tambah suara
        audioSource.Play();
        this.gameObject.SetActive(false);
    }
}
