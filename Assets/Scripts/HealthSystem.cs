using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _inactiveAfterDamageTime;
    [SerializeField] private Collider2D _collider;
    
    void Start()
    {
        _currentHealth = _maxHealth;
    }
    
    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        StartCoroutine(DeactivateCollider());
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }

    private IEnumerator DeactivateCollider()
    {
        _collider.enabled = false;
        yield return new WaitForSeconds(_inactiveAfterDamageTime);
        _collider.enabled = true;
    }
    
}
