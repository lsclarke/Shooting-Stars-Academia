using System.Collections;
using UnityEngine;

public class StartQuestonSequence : MonoBehaviour, IInteractable
{
    [SerializeField]
    private TestQuestionCanvas testQuestionCanvas;
    [SerializeField]
    private TestQuestionManager testQuestionManager;
    [SerializeField]
    private GameObject InteractCanvas;
    [SerializeField]
    private PlayerInteract playerInteract;

    [SerializeField]
    private StarBoy starBoy;

    [SerializeField]
    private int ProblemNumber;

    [SerializeField]
    private bool colorMatchRequired;
    [SerializeField]
    private bool colorMatched;

    ///This represents the color mode the player is in, based on this the player will be able to perform different abilities
    public enum colorMatch
    {
        BASE,
        RED,
        YELLOW,
        BLUE,
        GREEN,
        ORANGE,
        PURPLE
    }

    [Space(10f)]
    public colorMatch colorType;//BASE

    public void SetProblemNumber(int value)
    {
        ProblemNumber = value;
    }

    public int GetProblemNumber()
    {
        return ProblemNumber;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InteractCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InteractCanvas.SetActive(false);
        }
    }


    public void StartColorCrisis()
    {
        if (colorMatchRequired)
        {
            if(starBoy.zone.ToString() == colorType.ToString())
            {
                colorMatched = true;
            }
            else
            {
                colorMatched = false;
            }

            if (colorMatched)
            {
                starBoy.isActive = false;
                testQuestionManager.TurnOnCrisisProblemScreen();
                testQuestionCanvas.setIsOnParameter(true);
            }
        }
        else
        {
            starBoy.isActive = false;
            testQuestionManager.TurnOnCrisisProblemScreen();
            testQuestionCanvas.setIsOnParameter(true);
        }
    }

    public void Interact()
    {
        StartColorCrisis();
    }
}
