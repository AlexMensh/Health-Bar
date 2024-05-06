using UnityEngine;

public abstract class HealthBar : MonoBehaviour
{
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }
    private void OnEnable()
    {
        _health.HealthChanged += DrawUI;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= DrawUI;
    }

    public abstract void DrawUI(float health, float maxHealth);
}
