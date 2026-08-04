using UnityEngine;

[CreateAssetMenu(fileName = "ColorCrisisManager", menuName = "Scriptable Objects/ColorCrisisManager")]
public class ColorCrisisManager : ScriptableObject
{

    public string[] problemQuestions;
    public string[] correctAnswers;
    public string[] wrongAnswers;

    public float timerLimit;
}
