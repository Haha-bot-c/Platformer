using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Health))]

public class LifeDrain : TriggerAttak
{
    [SerializeField] private float _duration = 6f;

    private void Update()
    {
        if (_attack == null && Input.GetKeyDown(KeyCode.E))
        {
            _attack = StartCoroutine(AttackCoroutine());
        }
    }

    private IEnumerator AttackCoroutine()
    {
        float elapsedTime = 0f;
        
        WaitForSeconds wait = new WaitForSeconds(_attackCooldown);

        while (_charactersInRange.Count > NullIndex && elapsedTime < _duration)
        {
            foreach (Collider2D character in _charactersInRange)
            {
                character.GetComponent<Health>().TakeDamage(_attackDamage);
                GetComponent<Health>().Heal(_attackDamage);
            }
            
            yield return wait;

            elapsedTime += _attackCooldown; 
            
            if(elapsedTime >= _duration)
                _attack = null;
        }
    }
}