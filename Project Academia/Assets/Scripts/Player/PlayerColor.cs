using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerColor : MonoBehaviour
{
    [SerializeField]
    private StarBoy starBoy;
    private bool wheelOn;

    [SerializeField]
    private GameObject colorWheelCanvas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wheelOn = false;
    }

    public void setWheelOn(bool value)
    {
        wheelOn = value;
    }

    public bool getWheelOn()
    {
        return wheelOn;
    }

    public void ToggleColorWheel()
    {
        wheelOn = !wheelOn;
        StartCoroutine("ColorWheelActive");
    }

    private IEnumerator ColorWheelActive()
    {
        yield return new WaitForSeconds(.01f);

        if (wheelOn)
        {
            colorWheelCanvas.SetActive(true);
            //Time.timeScale = 0.0f;
        }
        else
        {
            colorWheelCanvas.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }

    public void ColorWheel(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ToggleColorWheel();
        }
    }

}
