using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{  
    [SerializeField]
    private float speed;

    private Rigidbody2D _rigidbody;
    private Vector2 _movementInput;

    private Vector2 _smoothedMovementInput;
    private Vector2 _smoothVelocity;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _smoothedMovementInput = Vector2.SmoothDamp(
            _smoothedMovementInput,
            _movementInput,
            ref _smoothVelocity,
            0.1f);

        _rigidbody.velocity = _smoothedMovementInput * speed;
    }
    
    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }

}
