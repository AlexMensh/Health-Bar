using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _minHealth;
    [SerializeField] private float _healAmount;
    [SerializeField] private float _damage;

    public Action<float, float> OnHealthChanged;

    public void RestoreHealth()
    {
        _health = Mathf.Clamp(_health + _healAmount, _minHealth, _maxHealth);

        OnHealthChanged?.Invoke(_health, _maxHealth);
    }

    public void TakeDamage()
    {
        _health -= _damage;

        if (_health <= 0)
            _health = _minHealth;

        OnHealthChanged?.Invoke(_health, _maxHealth);
    }
}