using System.Collections;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject meteorPrefab;
    public float spawnInterval = 0.5f;   // thời gian giữa các lần rơi
    public float spawnXRange = 8f;       // phạm vi xuất hiện theo trục X
    public float spawnY = 6f;            // độ cao xuất hiện

    void Start()
    {
        InvokeRepeating(nameof(SpawnMeteor), 1f, spawnInterval);
    }

    void SpawnMeteor()
    {
        // Rơi meteor đầu tiên
        float x1 = Random.Range(-spawnXRange, spawnXRange);
        float delay1 = Random.Range(0f, 1.5f); // thời gian delay ngẫu nhiên
        StartCoroutine(SpawnMeteorWithDelay(x1, delay1));

        // Rơi meteor thứ hai (khác vị trí)
        float x2;
        do
        {
            x2 = Random.Range(-spawnXRange, spawnXRange);
        } while (Mathf.Abs(x2 - x1) < 1.5f); // tránh trùng vị trí gần nhau

        float delay2 = Random.Range(0f, 1.5f);
        StartCoroutine(SpawnMeteorWithDelay(x2, delay2));
    }

    IEnumerator SpawnMeteorWithDelay(float x, float delay)
    {
        yield return new WaitForSeconds(delay);
        Vector3 pos = new Vector3(x, spawnY, 0);
        Instantiate(meteorPrefab, pos, Quaternion.identity);
    }
}

