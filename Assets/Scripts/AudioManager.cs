using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField] GameObject menuMusic;
    [SerializeField] GameObject gameMusic;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            menuMusic.SetActive(true);
            gameMusic.SetActive(false);
        }
        else
        {
            menuMusic.SetActive(false);
            gameMusic.SetActive(true);
        }
    }
}
