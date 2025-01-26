using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DivisionProjectile : MonoBehaviour
{

    [SerializeField] float projectileDuration;
    [SerializeField] Vector3 projectileDir;
    [SerializeField] float projectileSpeed;

    private bool hitAnEdible;

    [SerializeField] float sizeLerpDuration;
    private Vector3 projectileSize;
    private Vector3 sizeToGain;

    [SerializeField] float moveToPlayerSpeed;

    private GameObject gumPile;

    [SerializeField] Rigidbody rb;


    [SerializeField] private float offsetMax;
    [SerializeField] private float offsetMin;
    private Vector3 offset;
    private bool followPlayer;
    // Start is called before the first frame update
    void Start()
    {
        //projectile size is set on instantiate

        Invoke(nameof(Pop), projectileDuration);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        if (!followPlayer)
        {
            rb.AddForce(projectileDir * projectileSpeed * Time.fixedDeltaTime, ForceMode.Force);
        }


    }

    private void GenerateOffset()
    {
        offset = new Vector3(Random.Range(offsetMin, offsetMax), 0,  Random.Range(offsetMin, offsetMax));

        if (Random.Range(1, 10) % 2 == 0)
            offset.x = offset.x * -1;

        if (Random.Range(1, 10) % 2 == 0)
            offset.z = offset.z * -1;
    }

    public void SetProjectileSize(Vector3 size)
    {
        projectileSize = size;
        transform.localScale = size;
    }

    public void SetProjectileDirection(Vector3 dir) 
    {
        projectileDir = dir;
    }

    private void Pop()
    {
        if (!hitAnEdible)
        {
            //  GameObject obj = Instantiate(gumPile);
            //  obj.GetComponent<Edible>().sizeIncrementValue = projectileSize;
            gameObject.SetActive(false);
        }
    }

    private void GainSize(Vector3 sizeIncrement)
    {
        StopAllCoroutines();

        sizeToGain = sizeIncrement + projectileSize;
        sizeToGain.z = projectileSize.z;

        Singleton.GetInstance.cameraManager.AdjustCamera(sizeIncrement.x);

        StartCoroutine(nameof(SizeLerp), sizeToGain);
    }

    IEnumerator SizeLerp(Vector3 desiredSize)
    {
        for (float t = 0f; t < sizeLerpDuration; t += Time.deltaTime)
        {
            transform.localScale = Vector3.Lerp(projectileSize, desiredSize, t / sizeLerpDuration);
            yield return null;
        }

        projectileSize = desiredSize;

        GenerateOffset();
        StartCoroutine(nameof(MoveToPlayer));
    }



    IEnumerator MoveToPlayer()
    {
        while (Vector3.Distance(transform.position, Singleton.GetInstance.playerPos.position) > 2)
        {
            Vector3 playerDir = -(transform.position - Singleton.GetInstance.playerPos.position).normalized;
            transform.Translate(playerDir * moveToPlayerSpeed * Time.deltaTime);
            yield return null;
        }

        Singleton.GetInstance.playerScript.GainSize(projectileSize);
        gameObject.SetActive(false);

    }



    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Edible"))
        {
            hitAnEdible = true;

            followPlayer = true;
            rb.velocity = Vector3.zero;


            Edible edible = collider.gameObject.GetComponent<Edible>();
            GainSize(edible.sizeIncrementValue);
            
            collider.gameObject.SetActive(false);

        }

      //  if (collider.gameObject.CompareTag("O NOME QUE FOR QUANDO O RAFA BOTAR LA NAS TAG"))
       // { 
       //     collider.gameObject.SetActive(false);
        //}
    }

}
