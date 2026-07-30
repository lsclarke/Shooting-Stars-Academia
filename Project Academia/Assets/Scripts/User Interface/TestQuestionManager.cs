using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TestQuestionManager : MonoBehaviour
{
    [SerializeField]
    private ColorCrisisManager crisisManager;
    [SerializeField]
    private StartQuestonSequence startQuestonSequence;


    //UI Text

    [SerializeField]
    private TextMeshProUGUI chromaQuestionTextMesh;

    [SerializeField]
    private TextMeshProUGUI answer1TextMesh;
    [SerializeField]
    private TextMeshProUGUI answer2TextMesh;
    [SerializeField]
    private TextMeshProUGUI answer3TextMesh;

    //UI Button

    //Int
    public int index;

    private bool canTurnOn = true;

    public void setContentContainerText()
    {
        if (startQuestonSequence.GetProblemNumber() == index)
        {
            chromaQuestionTextMesh.text = $"{crisisManager.problemQuestions[index]}";

            answer1TextMesh.text = $"{crisisManager.correctAnswers[index]}";
            answer2TextMesh.text = $"{crisisManager.wrongAnswers[index]}";
            answer3TextMesh.text = $"{crisisManager.wrongAnswers[index+1]}";
        }
    }

}
