using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerAttacker))]
public class MainCharacterController : MonoBehaviour
{
    [SerializeField] private float _checkRadius;
    [SerializeField] private Transform _feetPosition;
    [SerializeField] private LayerMask _contactGround;
    
    private Animator _animator;
    private int _idleState = 0;
    private int _walkState = 1;
    private int _jumpState = 2;

    private PlayerAttacker _playerAttacker;
    private PlayerMover _playerMover;

    private bool _isGrounded;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerAttacker = GetComponent<PlayerAttacker>();
        _playerMover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(_feetPosition.position, _checkRadius, _contactGround);

        if(_isGrounded == false)
            _animator.SetInteger("State", _jumpState);

        if (Input.GetMouseButtonDown(0))
        {
            _playerAttacker.Punch();
        }

        if (_isGrounded == true && Input.GetKey(KeyCode.Space))
            _playerMover.Jump();

        if (Input.GetButton("Horizontal") && _isGrounded)
        {
            _animator.SetInteger("State", _walkState);
            _playerMover.Walk();
        }
        else
        {
            if(Input.GetButton("Horizontal"))
                _playerMover.Walk();
            if (_isGrounded)
                _animator.SetInteger("State", _idleState);
        }
    }


    
}

