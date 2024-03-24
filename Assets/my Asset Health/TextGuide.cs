using UnityEngine;
using UnityEngine.UI;

public class TextGuide : HealthDisplay
{
    [SerializeField] private Text _healthText;

    protected override void HandleHealthChanged(float currentHealth, float maxHealth)
    {
        _healthText.text = $"{currentHealth}/{maxHealth}";
    }
}
