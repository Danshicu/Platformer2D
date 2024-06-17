using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Key : MonoBehaviour
{
    private bool _isPicked = false;
    public event Action OnPicked;

    private void Awake()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_isPicked) return;
        if (other.GetComponent<PlayerMovement>() == null) return;
        OnPicked?.Invoke();
        gameObject.SetActive(false);
        _isPicked = true;
    }
}
