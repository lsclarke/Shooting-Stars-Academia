using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//Lenard (Nova) Updated: 7/14/2025
//Editor Name/Discord Username, Date

public class PlayerUIController : MonoBehaviour
{
    //--Text Component References variables

    public bool CursorToggle;

    [Header("UI Text References")]
    [Space(10)]

    [SerializeField]
    private TextMeshProUGUI healthTextMesh;
    [SerializeField]
    private TextMeshProUGUI starPowerTextMesh;
    [SerializeField]
    private TextMeshProUGUI colorZoneTextMesh;


    [Space(10)]
    [Header("Component References")]
    [Space(10)]

    [SerializeField]
    private StarBoy starBoy;
    [SerializeField]
    private PlayerHealth playerHealth;

    [Space(10)]
    [Header("Slider & Image References")]
    [Space(10)]

    public Slider healthBarSlider;
    public Slider starPowerBarSlider;
    public Image colorZoneBarFill;
    public Image[] colorZoneShapeIcons;

    [SerializeField]
    private Sprite[] shapeImages;
    [SerializeField]
    public Color[] colorWheel;


    //--Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        setColorAndShapeIcon();
    }

    public void setSlidersAndText()
    {
        //Sliders
        healthBarSlider.value = starBoy.health;
        starPowerBarSlider.value = starBoy.stamina;

        //Text

        int hValue = (int)starBoy.health;
        int stpValue = (int)starBoy.stamina;

        healthTextMesh.text = $"HEALTH/{hValue}";
        starPowerTextMesh.text = $"STAR POWER/{stpValue}";
    }

    public void setColorAndShapeIcon()
    {
        foreach (var item in colorZoneShapeIcons)
        {
            switch (starBoy.zone)
            {
                case StarBoy.ColorZone.BASE:
                    item.sprite = shapeImages[0];
                    colorZoneBarFill.color = colorWheel[0];
                    colorZoneTextMesh.text = StarBoy.ColorZone.BASE.ToString();
                    break;
                case StarBoy.ColorZone.RED:
                    item.sprite = shapeImages[1];
                    colorZoneBarFill.color = colorWheel[1];
                    colorZoneTextMesh.text = StarBoy.ColorZone.RED.ToString();
                    break;
                case StarBoy.ColorZone.BLUE:
                    item.sprite = shapeImages[2];
                    colorZoneBarFill.color = colorWheel[2];
                    colorZoneTextMesh.text = StarBoy.ColorZone.BLUE.ToString();

                    break;
                case StarBoy.ColorZone.YELLOW:
                    item.sprite = shapeImages[3];
                    colorZoneBarFill.color = colorWheel[3];
                    colorZoneTextMesh.text = StarBoy.ColorZone.YELLOW.ToString();
                    break;
                case StarBoy.ColorZone.GREEN:
                    item.sprite = shapeImages[4];
                    colorZoneBarFill.color = colorWheel[4];
                    colorZoneTextMesh.text = StarBoy.ColorZone.GREEN.ToString();
                    break;
                case StarBoy.ColorZone.ORANGE:
                    item.sprite = shapeImages[5];
                    colorZoneBarFill.color = colorWheel[5];
                    colorZoneTextMesh.text = StarBoy.ColorZone.ORANGE.ToString();
                    break;
                case StarBoy.ColorZone.PURPLE:
                    item.sprite = shapeImages[6];
                    colorZoneBarFill.color = colorWheel[6];
                    colorZoneTextMesh.text = StarBoy.ColorZone.PURPLE.ToString();
                    break;
            }
        }
    }

    //--Update is called once per frame
    void Update()
    {
        setColorAndShapeIcon();
        setSlidersAndText();
    }
}
