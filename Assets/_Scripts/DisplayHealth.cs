
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
    public PlayerHealth Character;
    Image slider;

    private void Start()
    {
        GameTriggers.OnCharSelect += UpdateDisplay;
        slider = GetComponent<Image>();
    }
    private void OnEnable()
    {
        GameTriggers.OnCharSelect += UpdateDisplay;
    }

    private void OnDisable()
    {
        GameTriggers.OnCharSelect -= UpdateDisplay;
    }

    void UpdateDisplay()
    {
        slider.fillAmount = Character.CurrentHealth / Character.MaxHealth;
    }
}
