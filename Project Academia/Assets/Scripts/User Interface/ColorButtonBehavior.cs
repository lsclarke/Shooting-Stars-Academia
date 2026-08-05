using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ColorButtonBehavior : MonoBehaviour
{
    [SerializeField]
    private Image ShapeImage;
    private Button button;
    public float arcAmount = 0.8f;
    private EventSystem eventSystem;

    private Color originalColor = Color.white;
    public Color backgroundColor = Color.white;
    private void Start()
    {
        originalColor = ShapeImage.color;
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
    }
    private float SinAmount()
    {
        return Mathf.Sin(Time.time * arcAmount);
    }

}
