using UnityEngine;
using UnityEngine.UI;
using TMPro; // nếu dùng TextMeshPro
public class HPDisplay : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public PlayerScore player;   // tham chiếu đến Player
    public TextMeshProUGUI hpText;  // hoặc Text nếu bạn không dùng TMP

    void Update()
    {
        // Cập nhật HP liên tục trên màn hình
        hpText.text = "HP: " + player.score + " / 5";

        // Khi HP = 0 thì dừng game
        if (player.score <= 0)
        {
            Time.timeScale = 0f; // dừng toàn bộ chuyển động
            hpText.text = "GAME OVER!";
        }
    }
}
