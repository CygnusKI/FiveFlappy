using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab; // ��������I�u�W�F�N�g�̃v���n�u
    
    public float minSpawnTime = 1f; // �ŏ������Ԋu
    public float maxSpawnTime = 3f; // �ő吶���Ԋu
    public float minY = -5f; // Y���W�̍ŏ��l
    public float maxY = 5f;  // Y���W�̍ő�l

    public GameObject objectPrefab2;
    public float minSpawnTime2 = 1f; // �ŏ������Ԋu
    public float maxSpawnTime2 = 3f; // �ő吶���Ԋu
    public float minY2 = -5f; // Y���W�̍ŏ��l
    public float maxY2 = 5f;  // Y���W�̍ő�l

    public GameObject objectPrefab3;
    public float minSpawnTime3 = 1f; // �ŏ������Ԋu
    public float maxSpawnTime3 = 3f; // �ő吶���Ԋu
    public float minY3 = -5f; // Y���W�̍ŏ��l
    public float maxY3 = 5f;  // Y���W�̍ő�l


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
            Destroy(newObject, destroyTime); // 5�b��ɃI�u�W�F�N�g��j��
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
            Destroy(newObject, destroyTime); // 5�b��ɃI�u�W�F�N�g��j��
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
            Destroy(newObject, destroyTime); // 5�b��ɃI�u�W�F�N�g��j��
        }
    }
}
