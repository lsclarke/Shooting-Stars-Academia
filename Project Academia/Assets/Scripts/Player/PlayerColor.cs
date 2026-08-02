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

    public Color[] colorWheel;

    [SerializeField]
    private SpriteRenderer playerSpriteRenderer;
    private Material starBoyMaterial;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        starBoyMaterial = playerSpriteRenderer.material;
        starBoy.zone = StarBoy.ColorZone.BASE;
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

        switch (starBoy.zone)
        {
            case StarBoy.ColorZone.BASE:
                starBoyMaterial.SetColor("_StarBoyColor", colorWheel[0]);
                gameObject.layer = 6;
                setColorShift(false);
                break;
            case StarBoy.ColorZone.RED:
                starBoyMaterial.SetColor("_StarBoyColor", colorWheel[1]);
                gameObject.layer = 10;
                setColorShift(false);
                break;
            case StarBoy.ColorZone.BLUE:
                gameObject.layer = 12;
                starBoyMaterial.SetColor("_StarBoyColor", colorWheel[2]);
                setColorShift(false);
                break;
            case StarBoy.ColorZone.YELLOW:
                starBoyMaterial.SetColor("_StarBoyColor", colorWheel[3]);
                gameObject.layer = 11;
                setColorShift(false);
                break;
            case StarBoy.ColorZone.GREEN:
                starBoyMaterial.SetColor("_StarBoyColor", colorWheel[4]);
                gameObject.layer = 13;
                setColorShift(false);
                break;
            case StarBoy.ColorZone.ORANGE:
                starBoyMaterial.SetColor("_StarBoyColor", colorWheel[5]);
                gameObject.layer = 14;
                setColorShift(false);
                break;
            case StarBoy.ColorZone.PURPLE:
                starBoyMaterial.SetColor("_StarBoyColor", colorWheel[6]);
                gameObject.layer = 15;
                setColorShift(false);
                break;
        }
    }

    private IEnumerator ColorWheelActive()
    {
        yield return new WaitForSeconds(.01f);

        if (wheelOn)
        {
            starBoy.isActive = false;
            colorWheelCanvas.SetActive(true);
            Time.timeScale = 0.1f;
        }
        else
        {
            starBoy.isActive = true;
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
