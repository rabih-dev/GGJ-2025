using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerealBomb : MonoBehaviour
{
    void Start()
    {
        transform.parent = GameObject.FindGameObjectWithTag("Enemies").transform;
        Destroy(this.gameObject, 10f);
    }
}
