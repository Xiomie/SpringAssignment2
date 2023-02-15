using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float fireRate = 2f;
    public float moveSpeed = 2f;
    public float topY = 5f;
    public float bottomY = -5f;

    private Rigidbody2D rb2d;
    private float timeToFire = 0f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Move up until reaching the topY position, then move down until reaching the bottomY position.
        if (transform.position.y < topY)
        {
            rb2d.velocity = new Vector2(0f, moveSpeed);
        }
        else if (transform.position.y >= topY && transform.position.y > bottomY)
        {
            rb2d.velocity = new Vector2(0f, -moveSpeed);
        }

        // Shoot a bullet down at a regular interval.
        if (Time.time > timeToFire)
        {
            timeToFire = Time.time + 1f / fireRate;
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -bulletSpeed);
        Destroy(bullet, 3f);
    }
}

