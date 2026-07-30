using TMPro;
using UnityEngine;

public class ColorWheelCanvas : MonoBehaviour
{
    [SerializeField]
    private StarBoy starBoy;
    [SerializeField]
    private PlayerColor playerColorScript;
    [SerializeField]
    private ColorShiftCamera colorShiftCamera;

    [SerializeField]
    private TextMeshProUGUI colorZoneModeText;

    public void BaseButton()
    {
        starBoy.zone = StarBoy.ColorZone.BASE;
        colorZoneModeText.text = $"Zone: {starBoy.zone.ToString()}";
        ExitColorWheel();
        ActivateColorShift();
    }

    public void RedButton()
    {
        starBoy.zone = StarBoy.ColorZone.RED;
        colorZoneModeText.text = $"Zone: {starBoy.zone.ToString()}";
        ExitColorWheel();
        ActivateColorShift();
    }

    public void BlueButton()
    {
        starBoy.zone = StarBoy.ColorZone.BLUE;
        colorZoneModeText.text = $"Zone: {starBoy.zone.ToString()}";
        ExitColorWheel();
        ActivateColorShift();
    }

    public void YellowButton()
    {
        starBoy.zone = StarBoy.ColorZone.YELLOW;
        colorZoneModeText.text = $"Zone: {starBoy.zone.ToString()}";
        ExitColorWheel();
        ActivateColorShift();
    }

    public void GreenButton()
    {
        starBoy.zone = StarBoy.ColorZone.GREEN;
        colorZoneModeText.text = $"Zone: {starBoy.zone.ToString()}";
        ExitColorWheel();
        ActivateColorShift();
    }

    public void OrangeButton()
    {
        starBoy.zone = StarBoy.ColorZone.ORANGE;
        colorZoneModeText.text = $"Zone: {starBoy.zone.ToString()}";
        ExitColorWheel();
        ActivateColorShift();
    }

    public void PurpleButton()
    {
        starBoy.zone = StarBoy.ColorZone.PURPLE;
        colorZoneModeText.text = $"Zone: {starBoy.zone.ToString()}";
        ExitColorWheel();
        ActivateColorShift();
    }

    private void ActivateColorShift()
    {
        playerColorScript.setColorShift(true);
        colorShiftCamera.StartCameraFocus();
    }

    public void ExitColorWheel()
    {
        if (playerColorScript.getWheelOn())
        {
            playerColorScript.ToggleColorWheel();
        }
    }
}
