using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _movementSpeed;

    [SerializeField]
    private ChangeStateButton _stateButton;

    [SerializeField]
    private bool _isMoveable;

    private float _movement;

    private Vector3 _playerLocalScale;

    private Rigidbody2D _rigidbody;

    private AudioSource _audioSource;

    private CapsuleCollider2D _collider;

    public static PlayerController _singleton;

    private float _offset = 0.2f;

    private void Awake()
    {
        if (_singleton == null)
            _singleton = this;
        else
            Destroy(this.gameObject);
    }

    void Start()
    {

        _movementSpeed = 10f;
        _movement = 0;
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerLocalScale = transform.localScale;
        _collider = GetComponent<CapsuleCollider2D>();
        //_audioSource = GetComponent<AudioSource>();

    }

    void FixedUpdate()
    {
        float _input;
        if (_stateButton._state == 0) _input = Input.GetAxis("Horizontal");
        else _input = Input.acceleration.x;
        if (_isMoveable) _movement = _input * _movementSpeed; //Input.GetAxis("Horizontal") * Movement_Speed; //Input.acceleration.x * Movement_Speed;
        // Player look right or left
        if (_movement > 0)
            transform.localScale = new Vector3(_playerLocalScale.x, _playerLocalScale.y, _playerLocalScale.z);
        else if (_movement < 0)
            transform.localScale = new Vector3(-_playerLocalScale.x, _playerLocalScale.y, _playerLocalScale.z);

        // Calculate player velocity
        Vector2 _velocity = _rigidbody.velocity;
        _velocity.x = _movement;
        _rigidbody.velocity = _velocity;

        if (_velocity.y < 0)
            _collider.enabled = true;
        else
            _collider.enabled = false;

        Vector3 _topLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));

        if (transform.position.x > -_topLeft.x + _offset)
            transform.position = new Vector3(_topLeft.x - _offset, transform.position.y, transform.position.z);
        else if (transform.position.x < _topLeft.x - _offset)
            transform.position = new Vector3(-_topLeft.x + _offset, transform.position.y, transform.position.z);
    }

    void OnCollisionEnter2D(Collision2D Other)
    {
        Platform obj = Other.transform.GetComponent<Platform>();
        //if (obj = null) obj = Other.transform.GetComponentInChildren<Platform>();
        Vector2 _force = _rigidbody.velocity;
        _force.y = obj.GetValue();
        _rigidbody.velocity = _force;
    }
}
