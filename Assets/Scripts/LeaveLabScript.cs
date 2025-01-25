using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveLabScript : MonoBehaviour
{
    [SerializeField] GameObject mapLab;
    [SerializeField] GameObject mapCity;

    private void OnTriggerEnter(Collider other) 
    {
        mapLab.SetActive(false);    
        mapCity.SetActive(true);    
    }
}
