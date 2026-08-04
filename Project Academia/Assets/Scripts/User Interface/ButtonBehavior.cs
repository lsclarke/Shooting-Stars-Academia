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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();
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

    public void ButtonClicked()
    {
        Debug.Log($"{answerTextMesh.text.ToUpper()}");
        Debug.Log($"{testQuestionManager.GetCorrectAnswer().ToUpper()}");
        //Passed
        if (answerTextMesh.text == testQuestionManager.GetCorrectAnswer())
        {
            testQuestionManager.SetIsAnwserCorrect(true);

            if (testQuestionManager.GetIsAnwserCorrect())
            {

                testQuestionCanvas.setPassedParameter( true);
                testQuestionCanvas.setFailedParameter(false);
                testQuestionManager.SetPassFailString("Pass");
                obsticleBehavior.OnComplete?.Invoke();
            }
        }

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
}
