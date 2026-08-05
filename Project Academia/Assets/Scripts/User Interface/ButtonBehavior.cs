using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonBehavior : MonoBehaviour
{
    private Button button;

    [SerializeField]
    private TestQuestionManager testQuestionManager;
    [SerializeField]
    private TestQuestionCanvas testQuestionCanvas;

    [SerializeField]
    private TextMeshProUGUI answerTextMesh;

    [SerializeField]
    private ObsticleBehavior obsticleBehavior;

    [SerializeField]
    private StartQuestonSequence startQuestonSequence;

    [SerializeField]
    private StarBoy starBoy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();
        Debug.Log($"{testQuestionManager.GetCorrectAnswer().ToUpper()}");
    }

    public void TimeRanOut()
    {
        if (answerTextMesh.text != testQuestionManager.GetCorrectAnswer())//Failed
        {
            testQuestionManager.SetIsAnwserCorrect(false);

            if (!testQuestionManager.GetIsAnwserCorrect())
            {
                Debug.Log($"{answerTextMesh.text.ToUpper()}");
                Debug.Log($"DOES NOT MATCHES WITH");
                Debug.Log($"{testQuestionManager.GetCorrectAnswer().ToUpper()}");

                testQuestionCanvas.setPassedParameter(false);
                testQuestionCanvas.setFailedParameter(true);
                testQuestionManager.SetPassFailString("Wrong");
            }
        }
    }

    public void Passed()
    {
        Debug.Log($"{answerTextMesh.text.ToUpper()}, MATCHES WITH {testQuestionManager.GetCorrectAnswer().ToUpper()}");

        testQuestionManager.SetIsAnwserCorrect(true);

        if (testQuestionManager.GetIsAnwserCorrect())
        {
            testQuestionManager.SetTimerOn(false);
            testQuestionCanvas.setPassedParameter(true);
            testQuestionCanvas.setFailedParameter(false);
            testQuestionManager.SetPassFailString("Pass");
            obsticleBehavior.OnComplete?.Invoke();
        }
    }

    public void Failed()
    {
        testQuestionManager.SetIsAnwserCorrect(false);
        Debug.Log($"{answerTextMesh.text.ToUpper()}, DOES NOT MATCHES WITH {testQuestionManager.GetCorrectAnswer().ToUpper()}");

        if (!testQuestionManager.GetIsAnwserCorrect())
        {
            Debug.Log($"{answerTextMesh.text.ToUpper()}");
            Debug.Log($"DOES NOT MATCHES WITH");
            Debug.Log($"{testQuestionManager.GetCorrectAnswer().ToUpper()}");
            testQuestionManager.SetTimerOn(false);
            testQuestionCanvas.setPassedParameter(false);
            testQuestionCanvas.setFailedParameter(true);
            testQuestionManager.SetPassFailString("Wrong");
            obsticleBehavior.OnInComplete?.Invoke();
        }
    }

    public void ButtonClicked()
    {
        //Passed
        if (answerTextMesh.text == testQuestionManager.GetCorrectAnswer())
        {
            Passed();
        } 
        else if (answerTextMesh.text != testQuestionManager.GetCorrectAnswer())//Failed
        {
            Failed();
        }
        

        

    }
}
