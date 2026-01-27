using UnityEngine;

public class Star : MonoBehaviour
{
    private Vector2 direction;
    private float speed;

    void Start()
    {
        // Hướng rơi ngẫu nhiên (xuống, chéo trái hoặc phải)
        float angle = Random.Range(-60f, 60f);
        direction = Quaternion.Euler(0, 0, angle) * Vector2.down;

        // Tốc độ rơi ngẫu nhiên
        speed = Random.Range(0.3f, 1.2f);
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        // Nếu rơi quá xa thì tự xóa
        if (transform.position.y < -6f)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerScore playerScore = collision.GetComponent<PlayerScore>();
            if (playerScore != null && playerScore.score != 5)
            {
                playerScore.score += 1;
                Debug.Log("Thu thập sao! Điểm: " + playerScore.score);
            }

            Destroy(gameObject); // biến mất khi thu thập
        }
    }
}
