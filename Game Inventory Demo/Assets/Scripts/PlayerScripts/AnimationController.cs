using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    
    private readonly int moving = Animator.StringToHash("isMoving");

    private const float FlipVelocityThreshold = 0.1f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        var isMoving = _rigidbody.velocity.magnitude > 0.1f;
        _animator.SetBool(moving, isMoving);
        
        SetCharacterOrientation();
    }
    
    
    private void SetCharacterOrientation()
    {
        transform.localScale = _rigidbody.velocity.x > FlipVelocityThreshold
            ? new Vector3(-1, 1, 1)
            : new Vector3(1, 1, 1);
    }
}
