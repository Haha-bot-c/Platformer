using UnityEngine;

public abstract class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Health _health;

    protected virtual void OnEnable()
    {
        _health.Changed += HandleHealthChanged;
    }

    protected virtual void OnDisable()
    {
        _health.Changed -= HandleHealthChanged;
    }

    protected abstract void HandleHealthChanged(float currentHealth, float maxHealth);
}
