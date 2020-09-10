using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides player movement.
/// </summary>
public class PlayerController : MonoBehaviour
{
    public Transform cam;
    private Transform playerTransform;
    private CharacterController controller;
    private Vector3 spawnPosition;
    private float speed = 10f;
    private float jumpHeight = 3.5f;
    private float gravity = -11.81f;
    private Vector3 velocity;

    /// <summary>
    /// Initializes components and spawn position.
    /// </summary>
    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerTransform = GetComponent<Transform>();
        spawnPosition = playerTransform.position;
        spawnPosition.y += 20;
    }

    /// <summary>
    /// Computes player movement every frame.
    /// </summary>
    void Update()
    {
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -0.01f;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 force = Vector3.zero;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            force =  moveDir * speed * Time.deltaTime;
        }

        if (controller.isGrounded && Input.GetButton("Jump"))
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime + force);

        if (playerTransform.position.y < -20)
        {
            playerTransform.position = spawnPosition;
        }
    }
}