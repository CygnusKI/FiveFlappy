using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab; // 生成するオブジェクトのプレハブ
    
    public float minSpawnTime = 1f; // 最小生成間隔
    public float maxSpawnTime = 3f; // 最大生成間隔
    public float minY = -5f; // Y座標の最小値
    public float maxY = 5f;  // Y座標の最大値

    public GameObject objectPrefab2;
    public float minSpawnTime2 = 1f; // 最小生成間隔
    public float maxSpawnTime2 = 3f; // 最大生成間隔
    public float minY2 = -5f; // Y座標の最小値
    public float maxY2 = 5f;  // Y座標の最大値

    public GameObject objectPrefab3;
    public float minSpawnTime3 = 1f; // 最小生成間隔
    public float maxSpawnTime3 = 3f; // 最大生成間隔
    public float minY3 = -5f; // Y座標の最小値
    public float maxY3 = 5f;  // Y座標の最大値


    public float destroyTime = 10f;

    void Start()
    {
        StartCoroutine(SpawnObject());
        StartCoroutine(SpawnObject2());
        StartCoroutine(SpawnObject3());
    }

    IEnumerator SpawnObject()
    {
        while (true)
        {
            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(waitTime);

            float randomY = Random.Range(minY, maxY);
            Vector3 spawnPosition = new Vector3(transform.position.x, randomY, transform.position.z);

            GameObject newObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
            Destroy(newObject, destroyTime); // 5秒後にオブジェクトを破壊
        }
    }

    IEnumerator SpawnObject2()
    {
        while (true)
        {
            float waitTime = Random.Range(minSpawnTime2, maxSpawnTime2);
            yield return new WaitForSeconds(waitTime);

            float randomY = Random.Range(minY2, maxY2);
            Vector3 spawnPosition = new Vector3(transform.position.x, randomY, transform.position.z);

            GameObject newObject = Instantiate(objectPrefab2, spawnPosition, Quaternion.identity);
            Destroy(newObject, destroyTime); // 5秒後にオブジェクトを破壊
        }
    }

    IEnumerator SpawnObject3()
    {
        while (true)
        {
            float waitTime = Random.Range(minSpawnTime3, maxSpawnTime3);
            yield return new WaitForSeconds(waitTime);

            float randomY = Random.Range(minY3, maxY3);
            Vector3 spawnPosition = new Vector3(-transform.position.x, randomY, transform.position.z);

            GameObject newObject = Instantiate(objectPrefab3, spawnPosition, Quaternion.identity);
            Destroy(newObject, destroyTime); // 5秒後にオブジェクトを破壊
        }
    }
}
