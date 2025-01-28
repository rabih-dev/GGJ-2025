using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
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
    private Vector3 sizeToGain;
    private Vector3 sizeToLose;

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

    bool hm = false;

    private void FixedUpdate()
    {
        PleaseStopFlying();
        Movement();

        if (!hm && GetSize().x > 4f)
        {
            hm = true;
            GameObject.FindGameObjectWithTag("Finish").GetComponent<WaveManager>().ActiveHardmode();
        }
    }

    private void Movement()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        //multiplying by 100 just because i dont like large numbers on inspector
        moveForce = moveInput * moveSpeed * 100 * Time.fixedDeltaTime;

        //using this for more snapy controls
        rb.velocity = new Vector3(moveForce.x, rb.velocity.y, moveForce.y);
    }

    public Vector3 GetSize()
    {
        return playerSize;
    }

    private void PleaseStopFlying()
    {
        if (rb.velocity.y > 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        }
    }
    public void GainSize(Vector3 sizeIncrement)
    {
        sizeIncrement = new Vector3(sizeIncrement.x/3, sizeIncrement.x/3, sizeIncrement.x/3);

        sizeToGain = sizeIncrement + playerSize;

        moveSpeed += sizeIncrement.x/2.65f;

        Singleton.GetInstance.cameraManager.ZoomOutCamera(sizeIncrement.x*3.5f);

        StartCoroutine(nameof(SizeLerp), sizeToGain);
    }

    public void LoseSize(Vector3 sizeDecrement)
    {
        sizeToLose = playerSize - sizeDecrement;

        moveSpeed -= sizeToLose.x;

        StartCoroutine(nameof(SizeLerp), sizeToLose);
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
            StartCoroutine(nameof(EatEdible), collider);
        }
    }

    IEnumerator EatEdible(Collider collider)
    {
        yield return new WaitForSeconds(0.1f);

        Edible edible = collider.gameObject.GetComponent<Edible>();

        if (edible.canEatSize <= playerSize.x)
        {
            GainSize(edible.sizeIncrementValue);
            collider.gameObject.SetActive(false);
            if (collider.gameObject.GetComponent<KamikazeBehaviour>() == null)
            {
                GetComponent<LifeDino>().AddLife();
            }
        }
    }

}
