using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ObsticleBehavior : MonoBehaviour
{
    public UnityEvent OnComplete;
    public UnityEvent OnInComplete;
    public int colorLayerIndex;
    public SpriteRenderer sprite;
    [SerializeField]
    public Color newColor;

    public void SetColor()
    {
        sprite.color = newColor;
    }

    public void setLayer()
    {
        gameObject.layer = colorLayerIndex;
    }

    public void setExcludeLayer()
    {
        gameObject.GetComponent<Collider2D>().excludeLayers = LayerMask.GetMask("BLUE");
    }
}
