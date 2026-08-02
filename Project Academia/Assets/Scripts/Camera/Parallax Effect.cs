using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
//Lenard (Nova) Updated: 7/17/2025
//Editor Name/Discord Username, Date
public class ParallaxEffect : MonoBehaviour
{
    private float length, startpoint;
    public Camera Cam;
    public float parallaxEffect;

    private void Start()
    {
        InitializeVars();
    }
    void InitializeVars()
    {
        startpoint = this.transform.position.x;
        //length = this.GetComponent<TilemapRenderer>().bounds.size.x;
    }

    /// <summary>
    /// Change the x position of the gameObject depending on the camera's current x position
    /// </summary>
    private void FixedUpdate()
    {
        float distance = (Cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startpoint + distance, transform.position.y, transform.position.z);
    }

}
