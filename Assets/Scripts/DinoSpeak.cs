using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoSpeak : MonoBehaviour
{
    [Header("Sounds")]
    [SerializeField] private AudioSource dino;
    [SerializeField] private AudioClip[] dinoSounds;
    [SerializeField] private AudioClip DeathSound;

    void Start()
    {
        StartCoroutine(Speak());
    }

    IEnumerator Speak()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5, 15));
            dino.PlayOneShot(dinoSounds[Random.Range(0, dinoSounds.Length)]);
        }
    }

    public void StopSpeaking()
    {
        StopAllCoroutines();
        dino.PlayOneShot(DeathSound);
    }
}
