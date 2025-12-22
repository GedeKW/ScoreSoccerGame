using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTimerManager : MonoBehaviour
{
    public static AddTimerManager Instance;

    [SerializeField] private List<Transform> spawnPoints;

    [SerializeField] private AddTimerDetector addTimerDetector;

    // public void CanMove
    private Coroutine spawnerCoroutine;

    [SerializeField]private float delay = 5f; 
    

    private void StopAddTimer()
    {
        addTimerDetector.hasDetected = true;
        addTimerDetector.gameObject.SetActive(false);
    }
    private void SpawnAddTimer()
    {
        int targetSpawn = Random.Range(0,spawnPoints.Count);
        addTimerDetector.gameObject.transform.position = spawnPoints[targetSpawn].position;
        addTimerDetector.gameObject.SetActive(true);
        addTimerDetector.hasDetected = false;
    }

    
    public void StopSpawnAddTimerManager()
    {
        if(spawnerCoroutine != null)
        {
            StopCoroutine(spawnerCoroutine);
            spawnerCoroutine = null;
        }
        StopAddTimer();
    }

    public void StartSpawnAddTimerManager()
    {
        if(spawnerCoroutine != null)
        {
            StopCoroutine(spawnerCoroutine);
            spawnerCoroutine = null;
        }
        spawnerCoroutine = StartCoroutine(Spawn_Cor());
    }

    IEnumerator Spawn_Cor()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            SpawnAddTimer();
        }
        yield return null;
    }

    void Awake()
    {
        if(Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            // DontDestroyOnLoad(this.gameObject);
        }
    }







}
