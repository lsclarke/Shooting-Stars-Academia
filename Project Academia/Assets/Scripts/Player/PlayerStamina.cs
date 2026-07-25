using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    [SerializeField]
    private StarBoy starBoy;
    private float MAX_STAMINA = 100f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        starBoy.stamina = MAX_STAMINA;
    }

    public void setStamina(float value)
    {
        starBoy.stamina = value;
    }

    public float getStamina()
    {
        return starBoy.stamina;
    }

    public float subtractStamina(float value)
    {
        float newStamina = starBoy.stamina - value;
        float stamina = Mathf.Lerp(starBoy.stamina, newStamina, 1f);

        starBoy.stamina = stamina;

        return starBoy.stamina;
    }

    public float addStamina(float value)
    {
        float newStamina = starBoy.stamina + value;
        float stamina = Mathf.Lerp(starBoy.stamina, newStamina, 1f);

        starBoy.stamina = stamina;

        return starBoy.stamina;
    }
}
