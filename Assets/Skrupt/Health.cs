using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    private const float MinHealth = 0;

    [SerializeField] private float _maxHealth = 100f;

    private float _currentHealth;

    public event Action<float, float> Changed;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float attackDamage)
    {
        if (attackDamage <= 0)
            return;
        if(_currentHealth <= 0)
            Destroy(gameObject);

        _currentHealth -= attackDamage;
        ModifyHealth(_currentHealth);
    }

    public void Heal(float amount)
    {
        if (amount <= 0)
            return;
        
        _currentHealth += amount;
        ModifyHealth(_currentHealth);
    }

    private void ModifyHealth(float currentHealth)
    {
        _currentHealth = Mathf.Clamp(currentHealth, MinHealth, _maxHealth);
        Changed?.Invoke(_currentHealth, _maxHealth);
    }
}
