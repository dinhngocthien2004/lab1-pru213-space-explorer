using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float fallSpeed = 2f;
    public float moveRange = 1f;
    public float moveSpeed = 2f;
    private float startX;
    private float destroyY;

    public int hitPoints = 6;

    void Start()
    {
        startX = transform.position.x;
        destroyY = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y - 1f;
    }

    void Update()
    {
        MoveMeteor();
        CheckAndDestroy();
    }

    void MoveMeteor()
    {
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;
        float xOffset = Mathf.Sin(Time.time * moveSpeed) * moveRange;
        transform.position = new Vector3(startX + xOffset, transform.position.y, 0);
    }

    void CheckAndDestroy()
    {
        if (transform.position.y < destroyY)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            hitPoints--;
            Destroy(collision.gameObject);

            if (hitPoints <= 0)
                Destroy(gameObject);
        }
        else if (collision.CompareTag("Player"))
        {
            // Trừ điểm khi va chạm
            PlayerScore playerScore = collision.GetComponent<PlayerScore>();
            if (playerScore != null)
            {
                playerScore.DecreaseScore(1); // trừ 1 điểm
            }

            Destroy(gameObject); // thiên thạch biến mất
        }
    }
}
