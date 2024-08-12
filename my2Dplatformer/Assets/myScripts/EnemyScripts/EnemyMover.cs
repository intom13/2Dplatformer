using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _patrollingSpeed;
    [SerializeField] private float _followingSpeed;
    [SerializeField] private float _patrollingDiameter;

    [SerializeField] private Sprite _patrollingStateSprite;
    [SerializeField] private Sprite _followingStateSprite;

    private Transform _transform;
    private SpriteRenderer _spriteRenderer;
    private Coroutine _attacking;
    private EnemyAttacker _enemyAttacker;

    private Vector3 _patrollingDiameterPoint;
    private Vector3 _targetPosition;

    private int _lookDirection = 1;
    private readonly float _lookDistance = 8f;
    private readonly int _reverseDirectionCoefficent = -1;

    private RaycastHit2D hit;
    private Vector3 _rayStartPositionX = new Vector3(2, 0, 0);
    private Vector3 _rayStartPositionY = new Vector3(0, 1, 0);

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _enemyAttacker = GetComponent<EnemyAttacker>();

        _patrollingDiameterPoint = new Vector3(_patrollingDiameter, 0, 0);
        _targetPosition = _transform.position + _patrollingDiameterPoint * _lookDirection;
    }

    private void Update()
    {
        Tracking();
    }

    private void Tracking()
    {
        hit = Physics2D.Raycast(_transform.position + _rayStartPositionY + _rayStartPositionX * _lookDirection, Vector2.right * _lookDirection * _lookDistance);
        Debug.DrawRay(_transform.position + _rayStartPositionY + _rayStartPositionX * _lookDirection, _transform.right * _lookDirection * _lookDistance, Color.black, 1);

        if (hit)
        {
            if (hit.collider.TryGetComponent(out Player player))
                Following(player.transform);
            else
                Patrolling();
        }
        else
        {
            Patrolling();
        }
    }

    private void Patrolling()
    {
        if (_attacking != null)
        {
            StopCoroutine(_attacking);
            _attacking = null;
        }

        if (_targetPosition != null)
        {
            if (_transform.position.x != _targetPosition.x)
                _transform.position = Vector3.MoveTowards(_transform.position, _targetPosition, _patrollingSpeed * Time.deltaTime);
            else
            {
                _lookDirection *= _reverseDirectionCoefficent;
                
                _targetPosition = _transform.position + _patrollingDiameterPoint * _lookDirection;
            }
        }

        if (_spriteRenderer.sprite == _followingStateSprite)
            _spriteRenderer.sprite = _patrollingStateSprite;
    }

    private void Following(Transform target)
    {
        if (_attacking == null)
        {
            _attacking = StartCoroutine(_enemyAttacker.Attacking());
        }
        
        if (target != null && _transform.position != target.position)
            _transform.position = Vector2.MoveTowards(_transform.position, target.position, _followingSpeed * Time.deltaTime);

        if (_spriteRenderer.sprite == _patrollingStateSprite)
            _spriteRenderer.sprite = _followingStateSprite;
    }
}
