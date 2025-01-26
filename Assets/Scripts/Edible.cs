using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edible : MonoBehaviour
{
    public Vector3 sizeIncrementValue;
    [SerializeField] private bool enteredCollectRange;
    [SerializeField] private float lerpDuration;
    [SerializeField] private float collectRange;

    [SerializeField] private GameObject canEatHUD;
    public float cantEatSize;

    Player player;

    Vector3 collectedPosition;
    Vector3 positionToLerp;

    void Start()
    {
        player = Singleton.GetInstance.playerScript;
        enteredCollectRange = false;
    }

    // Update is called once per frame
    void Update()
    {

        //retirar?
        DisplayCanEat();

        if (Vector3.Distance(transform.position, Singleton.GetInstance.playerPos.position) < collectRange)
        {
            enteredCollectRange = true;
            collectedPosition = transform.position;
            positionToLerp = Singleton.GetInstance.playerPos.position;
        }

        if (enteredCollectRange)
        {
            transform.position = Vector3.Lerp(collectedPosition, positionToLerp, lerpDuration * Time.deltaTime);
        }

    }

    private void DisplayCanEat()
    {
        if (cantEatSize <= player.GetSize().x)
        {
            canEatHUD.SetActive(true);
        }

        else 
        {
            canEatHUD.SetActive(false);
        }
    }
}
