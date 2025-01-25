using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;


public class Singleton : MonoBehaviour
{
    public Transform playerPos;

    public CameraManager cameraManager;

    private static Singleton instance;

    public static Singleton GetInstance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<Singleton>();
            }
            return instance;
        }
    }
}