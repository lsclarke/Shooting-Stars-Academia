using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ObsticleBehavior : MonoBehaviour
{
    public UnityEvent OnComplete;
    public int colorLayerIndex;
    public SpriteRenderer sprite;
    [SerializeField]
    public Color newColor;

    [SerializeField]
    private Collider2D playerCollider;

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
