using System.Collections;
using System.Collections.Generic;
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
            SceneManager.LoadScene("Win");
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
                    StartCoroutine(DeathCooldown());
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
                    StartCoroutine(DeathCooldown());
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

    private IEnumerator DeathCooldown()
    {
        GetComponent<DinoSpeak>().StopSpeaking();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("GameOver");
    }

    private bool canTakeDamage = true;
    private IEnumerator DamageCooldown()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(1);
        canTakeDamage = true;
    }
}
