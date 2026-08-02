using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManagerController : MonoBehaviour
{
    public CameraManagerSystem cameraManagerSystem;
    public Camera[] overlayCameras;
    private float originalCameraSize;

    private void Start()
    {
        cameraManagerSystem.cameraSize = 5f;
        originalCameraSize = cameraManagerSystem.cameraSize;
        cameraManagerSystem.cameraTrackingLocation = GameObject.Find("Player Manager").GetComponent<Transform>();
    }
    public void FixedUpdate()
    {
        SetSizeAll();
    }


    public void SetSizeAll()
    {
        foreach (var item in overlayCameras)
        {
            item.orthographicSize = cameraManagerSystem.cameraSize;
        }
    }

}
