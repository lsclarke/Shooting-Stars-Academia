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
    private ColorWheelCanvas colorWheelCanvas;


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

    }

    public void setColorAndShapeIcon()
    {
        foreach (var item in colorZoneShapeIcons)
        {

        }
         
        switch (starBoy.zone)
        {
            case StarBoy.ColorZone.BASE:
                                        
                break;
            case StarBoy.ColorZone.RED:
                
                break;
            case StarBoy.ColorZone.BLUE:

                break;
            case StarBoy.ColorZone.YELLOW:

                break;
            case StarBoy.ColorZone.GREEN:

                break;
            case StarBoy.ColorZone.ORANGE:

                break;
            case StarBoy.ColorZone.PURPLE:

                break;
        }
    }

    //--Update is called once per frame
    void Update()
    {


    }
}
