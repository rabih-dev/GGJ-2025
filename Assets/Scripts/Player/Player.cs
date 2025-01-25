using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Movement")]
    [SerializeField] float moveSpeed;
    private Vector2 moveInput;
    private Vector2 moveForce;

    [Header("Size")]
    [SerializeField] float sizeLerpDuration;
    private Vector3 playerSize;

    [Header("References")]
    [SerializeField] private Rigidbody rb;

    void Start()
    {
        playerSize = transform.localScale;
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

    private void GainSize(Vector3 sizeIncrement)
    {
        Vector3 desiredSize = playerSize + sizeIncrement;
        desiredSize.z = playerSize.z;

        StartCoroutine(nameof(SizeLerp), desiredSize);
    }

    IEnumerator SizeLerp(Vector3 desiredSize)
    {
        for (float t = 0f; t < sizeLerpDuration; t += Time.deltaTime)
        {
            transform.localScale = Vector3.Lerp(playerSize, desiredSize, t / sizeLerpDuration);
            yield return null;
        }

        playerSize = desiredSize;
    }


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Edible"))
        {
            Edible edible = collider.gameObject.GetComponent<Edible>();
            GainSize(edible.sizeIncrementValue);
            collider.gameObject.SetActive(false);

        }
    }
}
