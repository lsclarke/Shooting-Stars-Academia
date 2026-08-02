using UnityEngine;

[CreateAssetMenu(fileName = "CameraManagerSystem", menuName = "Scriptable Objects/CameraManagerSystem")]
public class CameraManagerSystem : ScriptableObject
{
    public float cameraSize;
    public float duration;
    public bool inCameraTrigger;
    public bool widenCamera;
    public bool focusCamera;

    public Transform cameraTrackingLocation;

    public Transform focusTrackingLocation;

}
