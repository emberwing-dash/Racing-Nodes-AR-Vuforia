using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float rotateAngle = 15f; // angle per button press

    [SerializeField] FixedJoystick fJK;
    private Rigidbody rb;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float xVal = fJK.Horizontal;
        float yVal = fJK.Vertical;

        Vector3 movement = new Vector3(xVal, 0, yVal);

        // Move only (no auto rotation)
        rb.velocity = movement * speed * Time.deltaTime;
    }

    // 🚗 Rotate Left
    public void RotateLeft()
    {
        transform.Rotate(0, -rotateAngle, 0);
    }

    // 🚗 Rotate Right
    public void RotateRight()
    {
        transform.Rotate(0, rotateAngle, 0);
    }
}
