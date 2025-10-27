using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float _deadZone = 0.1f;
    [SerializeField] private float _moveSpeed = 500f;

    private KeyCode _moveRightKey = KeyCode.D;
    private KeyCode _moveLeftKey = KeyCode.A;
    private KeyCode _jumpKey = KeyCode.Space;

    private bool _jumpPerdormed = false;
    [SerializeField] private float _jumpForce = 5f;

    [SerializeField] private ParticleSystem _jumpEffects;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(_jumpKey))
        {
            _jumpPerdormed = true;
        }
    }

    private void FixedUpdate()
    {
        MoveCharacter();
        PerformJump();
    }

    private void PerformJump()
    {
        if (_jumpPerdormed)
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0, _rigidbody.velocity.z);
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _jumpPerdormed = false;
            AnimateJump();
        }
    }

    private void MoveCharacter()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > _deadZone)
        {
            _rigidbody.AddForce(new Vector3(Input.GetAxis("Horizontal"), 0, 0) * Time.deltaTime * _moveSpeed);
        }
    }

    private void AnimateJump()
    {
        if (_jumpEffects != null)
        {
            _jumpEffects.transform.position = gameObject.transform.position;
            _jumpEffects.Play();
        }
    }
}
