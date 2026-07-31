using UnityEngine;
using UnityEngine.UI;

public class TestQuestionCanvas : MonoBehaviour
{

    private Animator _animator;
    private bool isOn;
    [SerializeField]
    private TestQuestionManager testQuestionManager;
    private Button button;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponent<Animator>();
        isOn = false;
    }

    public void setIsOnParameter(bool value)
    {
        isOn = value;
    }

    public bool getIsOnParameter()
    {
        return isOn;
    }

    private void setAnimationParameters()
    {
        _animator.SetBool("isOn", isOn);
    }

    //When a button is pressed the system will check to see if the string is the same as the correct answer if it is, it will trigger a PASS.
    //If the wrong button is pressed then the system will FAIL and the player will be thrown back and forced to have to try again once re-interacting with the object
    public void ButtonAction()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        setAnimationParameters();
    }
}
