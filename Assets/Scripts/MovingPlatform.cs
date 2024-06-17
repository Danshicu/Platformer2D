using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float _moveDistance;

    [SerializeField] private float _moveTime;

    [SerializeField] private Vector2 _moveVector;
    private float _moveSpeed;
    
    void Start()
    {
        _moveSpeed = _moveDistance / _moveTime;
        InvokeRepeating(nameof(ChangeMoveDirection), _moveTime, _moveTime);          
    }

    private void FixedUpdate()
    {
        var vector3 = transform.position;
        vector3.x += _moveVector.x * _moveSpeed * Time.fixedDeltaTime;
        vector3.y += _moveVector.y * _moveSpeed * Time.fixedDeltaTime;
        transform.position = vector3;
    }
    
    private void ChangeMoveDirection()
    {
        _moveVector *= -1;
    }
}
