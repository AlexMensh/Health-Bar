using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _minHealth;
    [SerializeField] private float _healAmount;
    [SerializeField] private float _damage;

    public event Action<float, float> HealthChanged;

    public void Heal()
    {
        _health = Mathf.Clamp(_health + _healAmount, _minHealth, _maxHealth);

        HealthChanged?.Invoke(_health, _maxHealth);
    }

    public void TakeDamage()
    {
        _health -= _damage;

        if (_health <= 0)
            _health = _minHealth;

        HealthChanged?.Invoke(_health, _maxHealth);
    }
}