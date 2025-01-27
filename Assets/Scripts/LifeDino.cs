using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeDino : MonoBehaviour
{
    [SerializeField] int MaxLife = 3;
    [SerializeField] GameObject[] hudLife;
    [SerializeField] float tamanhoFinal;

    void FixedUpdate()
    {
        if(MaxLife > 0 && transform.GetComponent<Player>().GetSize().x >= tamanhoFinal)
        {
            //Ganhou
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Bullet")
        {
            if (canTakeDamage)
            {
                MaxLife--;

                if (MaxLife > 0)
                {
                    hudLife[MaxLife].SetActive(false);
                }
                else
                {
                    SceneManager.LoadScene("Menu");
                }

                StartCoroutine(DamageCooldown());
            }
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Bullet")
        {
            if (canTakeDamage)
            {
                MaxLife--;

                if (MaxLife > 0)
                {
                    hudLife[MaxLife].SetActive(false);
                }
                else
                {
                    SceneManager.LoadScene("Menu");
                }

                StartCoroutine(DamageCooldown());
            }
        }
    }

    public void AddLife()
    {
        if(MaxLife < 3)
        {
            MaxLife++;
            hudLife[MaxLife-1].SetActive(true);
        }
    }

    private bool canTakeDamage = true;
    private IEnumerator DamageCooldown()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(1);
        canTakeDamage = true;
    }
}
