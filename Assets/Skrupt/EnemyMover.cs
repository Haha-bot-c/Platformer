using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyMover : MonoBehaviour
{
    private const float ZeroOnX = 0;

    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _viewRadius =10f;
    
    private int _currentWaypointIndex = 0;
    private Vector2 _direction;
    private SpriteRenderer _spriteRenderer;
    private bool _canSeePlayer = false;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMover>())
        {
            _canSeePlayer = true;
            _direction = collision.transform.position - transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMover>())
        {
            _canSeePlayer = false;
        }
    }

    private void Update()
    {
        if( _canSeePlayer )
        {
            transform.Translate(_direction * _speed * Time.deltaTime);
            FlipSprait();
        }
        else
        {
            PatrolArea();
            FlipSprait();
        }
    }

    private void FlipSprait()
    {
        if (_direction.x > ZeroOnX)
        {
            _spriteRenderer.flipX = false;
        }
        else if (_direction.x < ZeroOnX)
        {
            _spriteRenderer.flipX = true;
        }
    }

    private void PatrolArea()
    {
        transform.position = Vector2.MoveTowards(transform.position, _waypoints[_currentWaypointIndex].position, _speed * Time.deltaTime);
        _direction = _waypoints[_currentWaypointIndex].position - transform.position;

        if (transform.position == _waypoints[_currentWaypointIndex].position)
        {
            _currentWaypointIndex = (++_currentWaypointIndex) % _waypoints.Length;
        }
    }
}
