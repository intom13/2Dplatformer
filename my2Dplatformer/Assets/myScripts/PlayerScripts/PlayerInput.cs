using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerAttacker))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float _checkRadius;
    [SerializeField] private Transform _feetPosition;
    [SerializeField] private LayerMask _contactGround;

    private readonly int _isMovingHorizontalParameter = Animator.StringToHash("IsMovingHorizontal");
    private readonly int _isGroundedParameter = Animator.StringToHash("IsGrounded");

    private readonly KeyCode _jumpKey = KeyCode.Space;
    private readonly int _attackMouseButton = 0;
    private readonly string _horizontalInputAxis = "Horizontal";

    private Animator _animator;
    private PlayerAttacker _playerAttacker;
    private PlayerMover _playerMover;

    private bool _isGrounded;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerAttacker = GetComponent<PlayerAttacker>();
        _playerMover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(_feetPosition.position, _checkRadius, _contactGround);

        if (!_isGrounded)
            _animator.SetBool(_isGroundedParameter, false);

        if (Input.GetMouseButtonDown(_attackMouseButton))
            _playerAttacker.Punch();

        if (_isGrounded && Input.GetKey(_jumpKey))
            _playerMover.Jump();

        if (Input.GetButton(_horizontalInputAxis) && _isGrounded)
        {
            _animator.SetBool(_isMovingHorizontalParameter, true);
            _animator.SetBool(_isGroundedParameter, true);
            _playerMover.Walk();
        }
        else if (_isGrounded)
        {
            _animator.SetBool(_isMovingHorizontalParameter, false);
            _animator.SetBool(_isGroundedParameter, true);
        }
        else if (Input.GetButton(_horizontalInputAxis))
        {
            _playerMover.Walk();
        }
    }
}

