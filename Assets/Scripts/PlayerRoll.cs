using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoll : MonoBehaviour
{

    public float rollSpeed = 10f;
    public float rollDistance = 3f;
    public float rollDuration = 1f;
    public AnimationCurve rollCurve;

    private bool isRolling = false;
    private Vector3 rollStartPosition;
    private float rollStartTime;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isRolling)
        {
            StartRoll();
        }
    }

    private void FixedUpdate()
    {
        if (isRolling)
        {
            float rollTime = Time.time - rollStartTime;
            float rollProgress = Mathf.Clamp01(rollTime / rollDuration);
            float rollHeight = rollDistance * rollProgress;

            // Calculate roll direction based on camera orientation
            Vector3 rollDirection = Quaternion.AngleAxis(-90f, Vector3.right) * Camera.main.transform.right;
            rollDirection.y = 0f;
            rollDirection.Normalize();

            transform.position = rollStartPosition + rollDirection * rollSpeed * rollTime + Vector3.up * rollHeight * rollCurve.Evaluate(rollProgress);

            if (rollProgress >= 1f)
            {
                EndRoll();
            }
        }
    }

    private void StartRoll()
    {
        isRolling = true;
        rollStartPosition = transform.position;
        rollStartTime = Time.time;
    }

    private void EndRoll()
    {
        isRolling = false;
    }
}




