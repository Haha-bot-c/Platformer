using UnityEngine;
using System.Collections;

public class Attack : TriggerAttak
{
    private void Update()
    {
        if (_attack == null && _nearestCharacterInRange != null)
        {
            _attack = StartCoroutine(BasicAttack());
        }
    }

    private IEnumerator BasicAttack()
    {
        WaitForSeconds wait = new(_attackCooldown);
        Health character = _nearestCharacterInRange.GetComponent<Health>();

        while (true)
        {
            character.TakeDamage(_attackDamage);
            
            yield return wait;
        }
    }
}
