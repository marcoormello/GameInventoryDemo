using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{  
    [SerializeField]
    private float speed;
    
    private float _flipVelocityThreshold = 0.1f;

    private Rigidbody2D _rigidbody;
    private Vector2 _movementInput;

    private Vector2 _smoothedMovementInput;
    private Vector2 _smooothVelocity;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _smoothedMovementInput = Vector2.SmoothDamp(
            _smoothedMovementInput,
            _movementInput,
            ref _smooothVelocity,
            0.1f);

        _rigidbody.velocity = _smoothedMovementInput * speed;

        SetCharacterOrientation();
    }
    
    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }

    private void SetCharacterOrientation()
    {
        transform.localScale = _rigidbody.velocity.x > _flipVelocityThreshold
            ? new Vector3(-1, 1, 1)
            : new Vector3(1, 1, 1);
    }
}
