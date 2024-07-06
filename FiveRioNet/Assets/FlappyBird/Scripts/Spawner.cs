using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public Pipes prefab;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 2f;
    public float verticalGap = 3f;

    private void OnEnable()
    {
        // 最初10sくらい出てこないように。
        StartCoroutine(ExecuteAfterDelay(10f));
        
    }
    private IEnumerator ExecuteAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        Pipes pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
        pipes.gap = verticalGap;
    }

    public void StartSpawing()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    public void StopSpawing()
    {
        CancelInvoke(nameof(Spawn));
    }

    public void UpdateSpawnRate(float newSpawnRate)
    {
        spawnRate = newSpawnRate;
        StopSpawing();
        StartSpawing();
    }

}
