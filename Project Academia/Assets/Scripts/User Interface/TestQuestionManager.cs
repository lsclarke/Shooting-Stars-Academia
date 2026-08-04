using System.Collections;
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

    [SerializeField]
    private ButtonBehavior buttonBehavior;

    //UI Text

    [SerializeField]
    private TextMeshProUGUI crisisProblemTextMesh;
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

    [SerializeField]
    private TextMeshProUGUI timerCountText;

    //Int

    public int index;

    //Bool

    private bool canTurnOn = true;
    private bool isAnwserCorrect;
    private bool timerOn;

    //Unity Events

    public UnityEvent OnActive;
    //Button

    private Button button;

    //Slider
    [SerializeField]
    private Slider timerProgressSlider;


    private void Start()
    {
        canTurnOn = true;
        timerOn = false;
        timerProgressSlider.maxValue = crisisManager.timerLimit;
        timerProgressSlider.value = timerProgressSlider.maxValue;
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
            crisisManager.timerLimit = 15f;
            isAnwserCorrect = false;
            OnActive?.Invoke();
            canTurnOn = false;
            StartCoroutine("startTimer");
        }
    }
    
    private IEnumerator startTimer()
    {
        yield return new WaitForSeconds(5f);
        timerOn = true;
    } 

    private void Update()
    {
        if (timerOn)
        {
            timerCountText.text = $"{Mathf.FloorToInt(crisisManager.timerLimit % 60f)}";
            crisisManager.timerLimit -= Time.deltaTime;
            timerProgressSlider.value = crisisManager.timerLimit;
            if (crisisManager.timerLimit <= 0f)
            {
                timerOn = false;
                crisisManager.timerLimit = timerProgressSlider.maxValue;
            }

            if (timerProgressSlider.value <= 0f)
            {
                buttonBehavior.TimeRanOut();
                timerOn = false;
            }

            //MUST UPDATE SLIDER TO SHOW FAIL WHEN TIMER RUNS OUT*******************************************
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
        int dice = 0;

        int roll = Random.Range(0,4);

        Debug.Log(roll);

        if (startQuestonSequence.GetProblemNumber() == index)
        {
            crisisProblemTextMesh.text = $"Color Crisis Problem No.{index+1}";
            chromaQuestionTextMesh.text = $"{crisisManager.problemQuestions[index]}";

            answer1TextMesh.text = $"{crisisManager.correctAnswers[index]}";
            answer2TextMesh.text = $"{crisisManager.wrongAnswers[index]}";
            answer3TextMesh.text = $"{crisisManager.wrongAnswers[index+1]}";
        }
    }

}
