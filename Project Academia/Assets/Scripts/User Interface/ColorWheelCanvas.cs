using TMPro;
using UnityEngine;

public class ColorWheelCanvas : MonoBehaviour
{
    [SerializeField]
    private StarBoy starBoy;
    [SerializeField]
    private PlayerColor playerColorScript;

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

    private void ActivateColorShift()
    {
        playerColorScript.setColorShift(true);
    }

    public void ExitColorWheel()
    {
        if (playerColorScript.getWheelOn())
        {
            playerColorScript.ToggleColorWheel();
        }
    }
}
