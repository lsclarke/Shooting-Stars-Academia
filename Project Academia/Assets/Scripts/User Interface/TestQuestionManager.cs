using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

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
    private TextMeshProUGUI passFailTextMesh;

    [SerializeField]
    private TextMeshProUGUI answer1TextMesh;
    [SerializeField]
    private TextMeshProUGUI answer2TextMesh;
    [SerializeField]
    private TextMeshProUGUI answer3TextMesh;

    //Int

    public int index;

    //Bool

    private bool canTurnOn = true;
    private bool isAnwserCorrect;

    //Unity Events

    public UnityEvent OnActive;
    //Button

    private Button button;

    private void Start()
    {
        canTurnOn = true;       
    }

    public bool CanTurnOnCanvas()
    {
        return canTurnOn;
    }

    public void setTimeLimit(float value)
    {
        crisisManager.timerLimit = value;
    }

    public float getTimeLimit()
    {
        return crisisManager.timerLimit;
    }


    public void TurnOnCrisisProblemScreen()
    {
        if (canTurnOn) {
            isAnwserCorrect = false;
            OnActive?.Invoke();
            canTurnOn = false;
        }
    }

    private void Update()
    {
        if (!canTurnOn)
        {
            crisisManager.timerLimit -= Time.deltaTime * 0.1f;
        }
    }

    public void SetPassFailString(string value)
    {
        passFailTextMesh.text = value;
    }

    public string GetPassFailString()
    {
        return passFailTextMesh.text;
    }

    public void SetIsAnwserCorrect(bool value)
    {
        isAnwserCorrect = value;
    }

    public bool GetIsAnwserCorrect()
    {
        return isAnwserCorrect;
    }

    public string GetCorrectAnswer()
    {
        return crisisManager.correctAnswers[index];
    }

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
