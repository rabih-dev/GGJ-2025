using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] float moveSpeed;
    private Vector2 moveInput;
    private Vector2 moveForce;

    [Header("References")]
    [SerializeField] private Rigidbody rb;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        //multiplying by 100 just because i dont like large numbers on inspector
        moveForce = moveInput * moveSpeed * 100 * Time.fixedDeltaTime;

        print("input é: " + moveInput);
        print("force é: " + moveForce);

        //using this for more snapy controls
        rb.velocity = new Vector3(moveForce.x, rb.velocity.y, moveForce.y);
    }
}
