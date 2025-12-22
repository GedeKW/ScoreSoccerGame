using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTimerManager : MonoBehaviour
{
    public static AddTimerManager Instance;

    [SerializeField] private List<Transform> spawnPoints;

    [SerializeField] private AddTimerDetector addTimerDetector;

    // public void CanMove

    private void StopAddTimer()
    {
        addTimerDetector.hasDetected = true;
        addTimerDetector.gameObject.SetActive(false);
    }
    private void SpawnAddTimer()
    {
        addTimerDetector.gameObject.SetActive(true);
        addTimerDetector.hasDetected = false;
    }

    
    public void StopSpawnAddTimerManager()
    {
        
    }

    public void StartSpawnAddTimerManager()
    {
        
    }








}
