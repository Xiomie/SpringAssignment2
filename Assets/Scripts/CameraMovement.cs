using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
   
    public float speed = 1f;

    private void Update()
    {
        transform.Translate(0f, speed * Time.deltaTime, 0f, Space.World);
    }
}
