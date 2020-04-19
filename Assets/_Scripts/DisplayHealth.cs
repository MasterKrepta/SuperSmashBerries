
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
    public PlayerHealth Character;
    public Button btn;
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
        if (slider != null)
        {
            slider.fillAmount = Character.CurrentHealth / Character.MaxHealth;
            if (Character.CurrentHealth <= 0)
            {
                btn.interactable = false;
            }
        }
        
    }
}
