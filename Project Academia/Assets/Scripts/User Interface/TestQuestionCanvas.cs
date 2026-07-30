using UnityEngine;

public class TestQuestionCanvas : MonoBehaviour
{

    private Animator _animator;
    private bool isOn;



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

    // Update is called once per frame
    void Update()
    {
        setAnimationParameters();
    }
}
