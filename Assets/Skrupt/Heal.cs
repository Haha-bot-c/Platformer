using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] private float _healAmount = 20f;

    public float GiveHealth()
    {
        return _healAmount;
    }
}
