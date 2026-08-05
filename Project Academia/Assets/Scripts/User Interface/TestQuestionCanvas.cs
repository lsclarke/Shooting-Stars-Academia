using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestQuestionCanvas : MonoBehaviour
{

    private Animator _animator;
    private bool isOn;
    private bool passed;
    private bool failed;
    [SerializeField]
    private TestQuestionManager testQuestionManager;
    private Button button;

    [SerializeField]
    private StarBoy starBoy;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponent<Animator>();
        isOn = false;
        passed = false;
        failed = false;
    }

    public void setIsOnParameter(bool value)
    {
        isOn = value;
    }

    public bool getIsOnParameter()
    {
        return isOn;
    }

    public void setPassedParameter(bool value)
    {
        passed = value;
    }

    public bool getPassedParameter()
    {
        return passed;
    }

    public void setFailedParameter(bool value)
    {
        failed = value;
    }
    public bool getFailedParameter()
    {
        return failed;
    }

    private void setAnimationParameters()
    {
        _animator.SetBool("isOn", isOn);
        _animator.SetBool("Pass", passed);
        _animator.SetBool("Fail", failed);
        starBoy.isActive = true;
    }

    public void ResetAnimationToIdle()
    {
        passed = false;
        failed = false; 
        isOn = false;
        starBoy.isActive = true;
    }

    public void StartTest()
    {
        testQuestionManager.setContentContainerText();
    }

    // Update is called once per frame
    void Update()
    {
        setAnimationParameters();
    }
}
