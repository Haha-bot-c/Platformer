using UnityEngine;
using System.Collections.Generic;

public abstract class TriggerAttak : MonoBehaviour
{
    protected const float NullIndex = 0f;

    [SerializeField] protected float _attackRange = 10f;
    [SerializeField] protected float _attackDamage = 10f;
    [SerializeField] protected float _attackCooldown = 1f;

    protected List<Collider2D> _charactersInRange = new();
    protected Coroutine _attack = null;

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Health>())
        {
            _charactersInRange.Add(other); 
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if (_charactersInRange.Contains(other))
        {
            _charactersInRange.Remove(other);
        }

        if (_charactersInRange.Count == NullIndex && _attack != null)
        {
            StopCoroutine(_attack);
            _attack = null;
        }
    }
}
