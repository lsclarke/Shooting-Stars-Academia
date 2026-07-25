using UnityEngine;

[CreateAssetMenu(fileName = "StarBoy", menuName = "Scriptable Objects/StarBoy")]
public class StarBoy : ScriptableObject
{
    ///Player Settings
    [Header("Star Boy Player Control Settings")]
    [TextArea()]
    public string Description;
    [Space(10f)]
    public float health;
    public float stamina;
    public float jumpForce;//7f

    [Space(10f)]
    public float walkSpeed;//75
    public float runSpeed;//225


    ///This represents the color mode the player is in, based on this the player will be able to perform different abilities
    public enum ColorZone
    {
        BASE,
        RED,
        GREEN,
        BLUE
    }

    [Space(10f)]
    public ColorZone zone;//BASE






}
