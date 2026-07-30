using System.Collections;
using UnityEngine;

public class ColorShiftCamera : MonoBehaviour
{
    private Camera mainCamera;
    private bool On;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    private void ShrinkCameraView()
    {
        mainCamera.orthographicSize -= Time.deltaTime * 10f;

        if (mainCamera.orthographicSize <= 3f)
        {
            mainCamera.orthographicSize = 3f;
        }
    }

    private void GrowCameraView()
    {
        mainCamera.orthographicSize += Time.deltaTime * 10f;

        if (mainCamera.orthographicSize >= 5f)
        {
            mainCamera.orthographicSize = 5f;
        }
    }

    public void StartCameraFocus()
    {
        StartCoroutine("CameraFocusIn");
    }

    private void Update()
    {
        if (On)
        {
            ShrinkCameraView();
        }
        else
        {
            GrowCameraView();
        }
    }

    private IEnumerator CameraFocusIn()
    {
        On = true;
        yield return new WaitForSeconds(.7f);
        On = false;
    }
}
