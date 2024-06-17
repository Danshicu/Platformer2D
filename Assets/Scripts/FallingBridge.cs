using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FallingBridge : MonoBehaviour
{
    [SerializeField] private Vector2 _fallDirection;
    [SerializeField] private float _fallSpeed;
    [SerializeField] private float _aliveAfterStepTime;
    private bool _isFalling;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>() != null)
        {
            StartCoroutine(Fall());
        }
    }

    private void FixedUpdate()
    {
        if (!_isFalling) return;
        var vector3 = transform.position;
        vector3 += new Vector3(_fallDirection.x, _fallDirection.y, 0) * _fallSpeed * Time.fixedDeltaTime;
        transform.position = vector3;
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(_aliveAfterStepTime);
        _isFalling = true;
    }
    
}
