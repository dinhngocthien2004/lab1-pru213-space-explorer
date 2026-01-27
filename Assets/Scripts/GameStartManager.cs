using UnityEngine;

public class GameStartManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject startButton; // nút Start

    void Start()
    {
        // Dừng toàn bộ game khi mới vào
        Time.timeScale = 0f;
    }

    // Hàm này được gọi khi bấm nút Start
    public void StartGame()
    {
        startButton.SetActive(false);  // ẩn nút Start
        Time.timeScale = 1f;           // tiếp tục game
    }
}
