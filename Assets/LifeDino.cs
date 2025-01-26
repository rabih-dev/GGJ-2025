using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeDino : MonoBehaviour
{
    [SerializeField] int MaxLife = 3;
    [SerializeField] GameObject[] hudLife;

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Bullet")
        {
            MaxLife--;

            if(MaxLife>0){hudLife[MaxLife].SetActive(false);}
            else 
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Bullet")
        {
            MaxLife--;

            if(MaxLife>0){hudLife[MaxLife].SetActive(false);}
            else 
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
