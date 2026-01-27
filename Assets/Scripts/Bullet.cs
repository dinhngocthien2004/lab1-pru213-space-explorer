using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 2f;

    void Start()
    {
        Destroy(gameObject, lifetime); // đạn tự hủy sau 3 giây
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime); // bay lên trên
    }
}
