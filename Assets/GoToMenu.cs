using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToMenu : MonoBehaviour
{
    [SerializeField] private float timeToGoToMenu = 21;

    void Start()
    {
        StartCoroutine(GoToMenuCoroutine());   
    }

    IEnumerator GoToMenuCoroutine()
    {
        yield return new WaitForSeconds(timeToGoToMenu);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
