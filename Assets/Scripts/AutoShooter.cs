using UnityEngine;

public class AutoShooter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject bulletPrefab; // Kéo prefab đạn vào
    public Transform firePoint;     // Vị trí bắn ra
    public float fireRate = 0.5f;   // Tốc độ bắn (0.5 giây/bullet)

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            Shoot();
            timer = 0;
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
