using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float acceleration = 1f;
    public float maxSpeed = 5f;
    public float verticalSpeed = 2f;
    public float speedBoost = 10f;
    public float speedBoostDuration = 1f;

    private CharacterController controller;
    private Vector3 movement;
    private Vector3 velocity;

    private bool isBoosting;
    private float boostTimeRemaining;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        movement = new Vector3(moveHorizontal, moveVertical, 0f);
        movement = Vector3.ClampMagnitude(movement, 1f);

        if (Input.GetKeyDown(KeyCode.Space) && !isBoosting)
        {
            isBoosting = true;
            boostTimeRemaining = speedBoostDuration;
            acceleration = speedBoost;
        }
    }

    private void FixedUpdate()
    {
        if (isBoosting)
        {
            boostTimeRemaining -= Time.fixedDeltaTime;
            if (boostTimeRemaining <= 0f)
            {
                isBoosting = false;
                acceleration = 1f;
            }
        }

        // Add the movement input to the horizontal velocity
        velocity += movement * acceleration * Time.fixedDeltaTime;
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        // Add the vertical speed to the vertical velocity
        velocity += new Vector3(0f, verticalSpeed, 0f) * Time.fixedDeltaTime;

        // Move the player with the final velocity vector
        controller.Move(velocity * Time.fixedDeltaTime);

        if (controller.isGrounded)
        {
            // Reset the vertical velocity if grounded
            velocity.y = 0f;
        }
    }
}

