using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Weapon weapon;
    public float dashSpeed = 3f;
    public float dashLength = .5f, dashCooldown = 1f;


    public GameObject projectilePrefab;
    public Transform launchOffset;
    private float dashCounter;
    private float dashCoolCounter;

    private Animator anim;

    Vector2 moveDirection;
    Vector2 mousePosition;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButtonDown(0))
        {
            weapon.Fire();
            anim.SetTrigger("attack");
        }

        moveDirection = new Vector2(moveX, moveY).normalized;

        if (Input.GetKeyDown(KeyCode.E))
        {
           anim.SetTrigger("Nose");

            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                moveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }
        if (dashCounter > 0)
        {
            
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                moveSpeed = 15f;
                dashCoolCounter = dashCooldown;
            }
        }
        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

    }


}
