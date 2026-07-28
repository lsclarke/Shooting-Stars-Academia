using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerColor : MonoBehaviour
{
    [SerializeField]
    private StarBoy starBoy;
    private bool wheelOn;
    private bool colorShifted;
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

    public void setColorShift(bool value)
    {
        colorShifted = value;
    }

    public bool getColorShift()
    {
        return colorShifted;
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

    public IEnumerator ColorShift()
    {
        yield return new WaitForSeconds(.05f);
        colorShifted = false;
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
