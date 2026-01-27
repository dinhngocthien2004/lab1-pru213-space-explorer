using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public PlayerScore player;          // Gán Player vào đây
    public GameObject gameOverPanel;    // Panel hiển thị Game Over
    public TextMeshProUGUI hpText;      // Hiển thị HP còn lại

    void Start()
    {
        gameOverPanel.SetActive(false); // Ẩn khi bắt đầu
    }

    void Update()
    {
        if (player == null) return;

        // Cập nhật HP text liên tục
        hpText.text = "HP: " + player.score + " / 5";

        // Khi điểm = 0 → hiện Game Over
        if (player.score <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Time.timeScale = 0f;              // Dừng game
        gameOverPanel.SetActive(true);    // Hiện bảng Game Over
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
