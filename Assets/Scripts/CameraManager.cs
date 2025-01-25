using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CameraManager : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    // Start is called before the first frame update
    void Start()
    {

    }


    public void AdjustCamera(float distanceIncrement)
    {
        CinemachineComponentBase componentBase = virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
        if (componentBase is CinemachineFramingTransposer)
        {
            (componentBase as CinemachineFramingTransposer).m_CameraDistance += distanceIncrement; // your value
        }
    }
}
