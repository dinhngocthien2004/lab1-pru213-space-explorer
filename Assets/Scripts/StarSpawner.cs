using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public GameObject starPrefab;
    public float spawnAreaWidth = 8f;
    public float spawnHeight = 6f;

    void Start()
    {
        // Bắt đầu spawn ngẫu nhiên
        StartCoroutine(SpawnStarsRandomly());
    }

    private System.Collections.IEnumerator SpawnStarsRandomly()
    {
        while (true)
        {
            float delay = Random.Range(0.5f, 3f); // thời gian chờ ngẫu nhiên
            yield return new WaitForSeconds(delay);

            // vị trí ngẫu nhiên theo trục X
            float randomX = Random.Range(-spawnAreaWidth / 2, spawnAreaWidth / 2);
            Vector3 spawnPos = new Vector3(randomX, spawnHeight, 0);

            Instantiate(starPrefab, spawnPos, Quaternion.identity);
        }
    }
}
