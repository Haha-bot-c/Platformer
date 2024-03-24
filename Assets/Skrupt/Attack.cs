using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Health))]

public class Attack : TriggerAttak
{
    private void Update()
    {
        if (_attack == null)
        {
            _attack = StartCoroutine(AttackCoroutine());
        }
    }

    private IEnumerator AttackCoroutine()
    {
        WaitForSeconds wait = new(_attackCooldown);

        while (_charactersInRange.Count > NullIndex)
        {
            foreach (Collider2D character in _charactersInRange)
            {
                character.GetComponent<Health>().TakeDamage(_attackDamage);
            }

            yield return wait;
        }
    }
}
