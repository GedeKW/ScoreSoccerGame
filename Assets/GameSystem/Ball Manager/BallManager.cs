using UnityEngine;

public class BallManager : MonoBehaviour
{
    public static BallManager Instance;
    [SerializeField] private Ball ball;
    [SerializeField] private Transform spawnLocation;


    void Awake()
    {
        if(Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

    }

    public void RestartBall()
    {
        ball.SetActive(false);
        ball.SetPosition(spawnLocation.position);
    }

    public void DropBall()
    {
        ball.SetActive(true);
    }
}
