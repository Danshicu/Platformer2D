using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Collider2D))]
public class HealthSystem : MonoBehaviour
{
    [field: SerializeField] public float MaxHealth { get; private set; }
    public float CurrentHealth { get; private set; }
    
    [SerializeField] private float _inactiveAfterDamageTime;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private HealthUI _healthUI;
    [SerializeField] private PlayerMovement _movement;

    private bool _damaged;
    
    void Start()
    {
        CurrentHealth = MaxHealth;
    }
    
    public void TakeDamage(float damage)
    {
        if (_damaged) return;
        _damaged = true;
        CurrentHealth -= damage;
        _healthUI.UpdateText(this);
        StartCoroutine(DeactivateCollider());
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        StartCoroutine(SceneLoader.RestartScene());
        _movement.DisableInput();
        _collider.enabled = false;
    }

    private IEnumerator DeactivateCollider()
    {
        _collider.enabled = false;
        yield return new WaitForSeconds(_inactiveAfterDamageTime);
        _collider.enabled = true;
        _damaged = false;
    }
    
}
