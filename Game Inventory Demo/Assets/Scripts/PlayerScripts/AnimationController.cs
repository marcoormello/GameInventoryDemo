using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    
    private readonly int moving = Animator.StringToHash("isMoving");

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        var isMoving = _rigidbody.velocity.magnitude > 0.1f;
        _animator.SetBool(moving, isMoving);
    }
}
