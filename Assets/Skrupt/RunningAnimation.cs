using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]

public class RunningAnimation : MonoBehaviour
{
    private const string IsRunning = "isRunning";

    private Animator _animator;
    private Rigidbody2D _rigidbody;

    private float _speedMove = 0.1f;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        bool isMoving = Mathf.Abs(_rigidbody.velocity.x) > _speedMove;

        _animator.SetBool(IsRunning, isMoving);
    }
}

