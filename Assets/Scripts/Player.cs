using UnityEngine;

[RequireComponent(typeof(UIDrawer))]
public class Player : MonoBehaviour
{
    [SerializeField] private UIDrawer _uIDrawer;
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _minHealt;
    [SerializeField] private float _healAmount;
    [SerializeField] private float _damage;

    void Start()
    {
        _uIDrawer = GetComponent<UIDrawer>();
        _uIDrawer.DrawUI(_health, _maxHealth);
    }

    public void RestoreHealth()
    {
        if (_health < _maxHealth)
        {
            _health += _healAmount;

            if (_health > _maxHealth)
                _health = _maxHealth;
        }

        _uIDrawer.DrawUI(_health, _maxHealth);
    }

    public void TakeDamage()
    {
        _health -= _damage;

        if (_health <= 0)
            _health = _minHealt;

        _uIDrawer.DrawUI(_health, _maxHealth);
    }
}