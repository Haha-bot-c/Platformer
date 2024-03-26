using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Health))]
public abstract class TriggerAttak : MonoBehaviour
{
    [SerializeField] protected float _attackDamage = 10f;
    [SerializeField] protected float _attackCooldown = 1f;

    protected Collider2D _nearestCharacterInRange = new();
    protected Coroutine _attack = null;

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Health healthComponent))
        {
            UpdateNearestCharacterInRange(other);
        }
    }
    
    protected virtual void OnTriggerExit2D(Collider2D other)
    { 
        if (other == _nearestCharacterInRange)
        {
            _nearestCharacterInRange = null;
        }

        if (_attack != null)
        {
            StopCoroutine(_attack);
            _attack = null;
        }
    }

    private void UpdateNearestCharacterInRange(Collider2D other)
    {
        if (_nearestCharacterInRange == null)
        {
            _nearestCharacterInRange = other;
        }
        else
        {
            float currentDistance = Vector2.Distance(transform.position, _nearestCharacterInRange.transform.position);
            float newDistance = Vector2.Distance(transform.position, other.transform.position);

            if (newDistance < currentDistance)
            {
                _nearestCharacterInRange = other;
            }
        }
    }
}
