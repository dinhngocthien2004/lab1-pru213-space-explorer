using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private float moveInputX;
    private float moveInputY;
    private SpriteRenderer sprite;

    private Vector2 minBounds; // giới hạn dưới/trái
    private Vector2 maxBounds; // giới hạn trên/phải

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        // Lấy giới hạn màn hình theo camera chính
        Camera cam = Camera.main;
        minBounds = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)); // góc trái dưới
        maxBounds = cam.ViewportToWorldPoint(new Vector3(1, 1, 0)); // góc phải trên
    }

    void Update()
    {
        moveInputX = Input.GetAxisRaw("Horizontal");
        moveInputY = Input.GetAxisRaw("Vertical");

        if (moveInputX > 0)
            sprite.flipX = false;
        else if (moveInputX < 0)
            sprite.flipX = true;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInputX * moveSpeed, moveInputY * moveSpeed);

        // Giới hạn vị trí player trong màn hình
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minBounds.x + 0.5f, maxBounds.x - 0.5f);
        pos.y = Mathf.Clamp(pos.y, minBounds.y + 0.5f, maxBounds.y - 0.5f);
        transform.position = pos;
    }
}
