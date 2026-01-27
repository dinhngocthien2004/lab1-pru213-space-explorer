using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int score = 5;
    public int maxScore = 5; // 🔹 Giới hạn điểm tối đa
    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // 🔹 Hàm tăng điểm (nếu nhặt sao)
    public void IncreaseScore(int amount)
    {
        score += amount;
        if (score > maxScore) score = maxScore; // Giới hạn tối đa
        Debug.Log("Player score: " + score);
    }

    // 🔹 Hàm giảm điểm (khi trúng thiên thạch)
    public void DecreaseScore(int amount)
    {
        score -= amount;
        if (score < 0) score = 0; // Không nhỏ hơn 0
        Debug.Log("Player score: " + score);

        // Bắt đầu hiệu ứng chớp nháy
        StartCoroutine(FlashPlayer());
    }

    private System.Collections.IEnumerator FlashPlayer()
    {
        int flashes = 4;
        float delay = 0.2f;

        for (int i = 0; i < flashes; i++)
        {
            sprite.enabled = false;
            yield return new WaitForSeconds(delay);
            sprite.enabled = true;
            yield return new WaitForSeconds(delay);
        }
    }
}
